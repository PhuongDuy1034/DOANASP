using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOANASP.Models
{
    public class Invoices
    {
        public int Id { get; set; }
        public string Code { get; set; }
       
        public Account Account { get; set; }
        public DateTime IssuedDate { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingPhone { get; set; }
        public int Total { get; set; }
        public bool Status { get; set; }
    }
}
