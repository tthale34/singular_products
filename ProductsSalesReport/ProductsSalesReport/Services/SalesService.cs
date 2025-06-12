using Microsoft.EntityFrameworkCore;
using ProductsSalesReport.Interfaces;
using ProductsSalesReport.Models;
using System.Net.Http.Json;

public class SalesService : ISalesService
{
    private readonly SalesReportContext _context;
    private readonly HttpClient _httpClient;

    public SalesService(SalesReportContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }
    public async Task<List<SalesReport>> GetAllSalesAsync()
    {
        var products = await _httpClient.GetFromJsonAsync<List<Product>>(
            "https://singularsystems-tech-assessment-sales-api2.azurewebsites.net/products");

        var allSales = new List<SalesReport>();

        foreach (var product in products)
        {
            var sales = await _httpClient.GetFromJsonAsync<List<SalesReport>>(
                $"https://singularsystems-tech-assessment-sales-api2.azurewebsites.net/product-sales?Id={product.id}");

            if (sales != null)
                allSales.AddRange(sales);
        }

        return allSales;
        _context.SalesReports.AddRange(allSales);
        await _context.SaveChangesAsync();

    }
    public async Task<IEnumerable<SalesReport>> GetAllSalesPerProductAsync(int? productId)
    {
        if (!_context.SalesReports.Any())
        {
            var sales = await _httpClient.GetFromJsonAsync<List<SalesReport>>(
                $"https://singularsystems-tech-assessment-sales-api2.azurewebsites.net/product-sales?Id={productId}");

            if (sales != null)
            {
                _context.SalesReports.AddRange(sales);
                await _context.SaveChangesAsync();
            }
        }

        return await _context.SalesReports.ToListAsync();
    }

    async Task<IEnumerable<SalesReport>> ISalesService.GetAllSalesAsync()
    {
        var products = await _httpClient.GetFromJsonAsync<List<Product>>(
            "https://singularsystems-tech-assessment-sales-api2.azurewebsites.net/products");

        var allSales = new List<SalesReport>();

        foreach (var product in products)
        {
            var sales = await _httpClient.GetFromJsonAsync<List<SalesReport>>(
                $"https://singularsystems-tech-assessment-sales-api2.azurewebsites.net/product-sales?Id={product.id}");

            if (sales != null)
                allSales.AddRange(sales);
        }

        _context.SalesReports.AddRange(allSales);
        await _context.SaveChangesAsync();

        return allSales;
    }
}
