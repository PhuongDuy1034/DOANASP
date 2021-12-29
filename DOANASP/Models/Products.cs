using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOANASP.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public ProductTypes ProductType { get; set; }
        public string Images { get; set; }
        public bool Status { get; set; }

    }
}
