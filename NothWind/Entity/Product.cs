using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NothWind.Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
    }
}
