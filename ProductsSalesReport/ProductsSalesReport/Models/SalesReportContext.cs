using Microsoft.EntityFrameworkCore;

namespace ProductsSalesReport.Models
{
    public class SalesReportContext : DbContext
    {
        public SalesReportContext(DbContextOptions<SalesReportContext> options) : base(options) { }

        public DbSet<SalesReport> SalesReports { get; set; }

    }
}
