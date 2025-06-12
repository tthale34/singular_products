using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsSalesReport.Models
{
    public class SalesReport
    {
        [Key]
        public int saleId { get; set; }
        [Column(TypeName = "int")]
        public int productId { get; set; }
        [Column(TypeName = "double")]
        public double salePrice { get; set; }
        [Column(TypeName = "int")]
        public int saleQty { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public DateTime saleDate { get; set; }
    }
}
