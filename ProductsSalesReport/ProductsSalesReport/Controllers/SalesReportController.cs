using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsSalesReport.Models;

namespace ProductsSalesReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportController : ControllerBase
    {
        private readonly SalesReportContext _context;

        public SalesReportController(SalesReportContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesReport>>> GetAllSales()
        {
            if (_context.SalesReports == null)
            {
                return NotFound();
            }
            var sales = await _context.SalesReports.ToListAsync();
            return Ok(sales);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetFiltered(int? productId, DateTime? from, DateTime? to, int page = 1, int pageSize = 50)
        //{
        //    return Ok(await _context.FilterSalesAsync(productId, from, to, page, pageSize));
        //}
    }
}
