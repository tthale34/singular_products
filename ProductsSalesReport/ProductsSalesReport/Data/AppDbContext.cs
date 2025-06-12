using Microsoft.EntityFrameworkCore;
using ProductsSalesReport.Models;

namespace ProductsSalesReport.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductContext> ProductContext { get; set; }
        public DbSet<SalesReportContext> SalesReportContext { get; set; }
        public object Sales { get; internal set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
