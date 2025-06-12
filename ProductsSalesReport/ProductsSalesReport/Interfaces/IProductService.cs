using ProductsSalesReport.Models;

namespace ProductsSalesReport.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
