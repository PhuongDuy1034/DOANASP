using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOANASP.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }
        public Invoices Invoice { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
