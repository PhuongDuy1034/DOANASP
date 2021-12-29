using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOANASP.Models
{
    public class Carts
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public Products Product { get; set; }
        public string Images { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
