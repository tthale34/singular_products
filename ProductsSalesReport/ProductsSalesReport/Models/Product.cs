using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsSalesReport.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string description { get; set; }
        public decimal salePrice { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string category { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string image { get; set; }
        public string summary { get; set; }
    }
}
