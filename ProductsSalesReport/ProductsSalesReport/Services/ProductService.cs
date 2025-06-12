using ProductsSalesReport.Models;

namespace ProductSalesReport.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("https://singularsystems-tech-assessment-sales-api2.azurewebsites.net/products");
            return products ?? new List<Product>();
        }
    }
}
