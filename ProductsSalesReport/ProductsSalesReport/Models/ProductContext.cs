using Microsoft.EntityFrameworkCore;
using ProductsSalesReport.Models;
using System.Collections.Generic;

namespace ProductsSalesReport.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
