using ProductsSalesReport.Models;

namespace ProductsSalesReport.Interfaces
{
    public interface ISalesService
    {
        //Task<IEnumerable<SalesReport>> GetAllSalesPerProductAsync(int? productId);
        //Task<IEnumerable<SalesReport>> FilterSalesAsync(int? productId, DateTime? fromDate, DateTime? toDate, int page, int pageSize);
        Task<IEnumerable<SalesReport>> GetAllSalesAsync();
    }
}
