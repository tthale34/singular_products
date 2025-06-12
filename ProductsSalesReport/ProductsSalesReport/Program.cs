using ProductSalesReport.Services;
using ProductsSalesReport.Models;
using Microsoft.EntityFrameworkCore;
;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// create memory storage
builder.Services.AddDbContext<ProductContext>(static options =>
    options.UseInMemoryDatabase("ProductDb"));
builder.Services.AddHttpClient<ProductService>();
builder.Services.AddDbContext<SalesReportContext>(static options =>
    options.UseInMemoryDatabase("SalesDb"));
builder.Services.AddHttpClient<SalesService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ProductContext>();
    var productService = services.GetRequiredService<ProductService>();

    var salesContext = services.GetRequiredService<SalesReportContext>();
    var salesService = services.GetRequiredService<SalesService>();

    try
    {
        var products = await productService.GetProductsAsync();

        // Merge sales summary into each product
        foreach (var product in products)
        {
            var salesReports = await salesService.GetAllSalesPerProductAsync(product.id);
            var totalSold = 0;
            double totalRevenue = 0.0;
            foreach (var sales_ in salesReports)
            {
                if (product.id == sales_.productId)
                {
                    totalSold = totalSold + sales_.saleQty;
                    totalRevenue = totalRevenue + sales_.salePrice;
                }
            }
            product.summary = $"{product.description} Sold {totalSold} units for R{Math.Round(totalRevenue, 2)}";
        }

        if (products != null && products.Any())
        {
            // saved to the database.
            if (!context.Products.Any())
            {
                context.Products.AddRange(products);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Database already contains products. Skipping seeding.");
            }
        }
        else
        {
            Console.WriteLine("No products returned from API.");
        }

        var sales = await salesService.GetAllSalesAsync();
        if (sales != null && sales.Any())
        {
            // saved to the database.
            if (!salesContext.SalesReports.Any())
            {
                salesContext.SalesReports.AddRange(sales);
                salesContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Database already contains sales. Skipping seeding.");
            }
        }
        else
        {
            Console.WriteLine("No sales returned from API.");
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error occurred while fetching products: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
