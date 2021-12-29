using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DOANASP.Models;

namespace DOANASP.Data
{
    public class DoanASPcontext : DbContext
    {
        public DoanASPcontext(DbContextOptions<DoanASPcontext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }
    }
}
