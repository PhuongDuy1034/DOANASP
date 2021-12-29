using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DOANASP.Data;
using DOANASP.Models;

namespace DOANASP.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly DoanASPcontext _context;

        public InvoicesController(DoanASPcontext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            // var result = from HoaDon in _context.Invoices
            // where HoaDon.Total >= 100001
            //select HoaDon;
          //var lstInvoices = _context.Invoices.Where(inv => inv.Total >= 500000);
           // return View(await _context.Invoices.ToListAsync());
            //var lstInvoices = _context.Invoices.OrderByDescending(inv => inv.IssuedDate).ThenBy(inv => inv.Total).Where(inv=>inv.Status==true);
            //var lstInvoices = _context.Invoices.OrderByDescending(inv => inv.IssuedDate).ThenBy(inv => inv.Total);
            // var lstInvoices = _context.Invoices.GroupBy(inv => inv.IssuedDate);
            // return View(await lstInvoices.ToListAsync());
            // return View();
        
            return View(await _context.Invoices.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoices == null)
            {
                return NotFound();
            }

            return View(invoices);
        }
        public IActionResult GroupByAccount()
        {
            var invoices = _context.Invoices.Include(i=>i.Account);
                return View(invoices.ToList());
        }
        public IActionResult GroupByAccount2()
        {
            var invoices = _context.Invoices.Include(i => i.Account);
            return View(invoices.ToList());
        }
        public IActionResult ByAccount()
        {
            var invoices = _context.Invoices.Include(i => i.Account).Where(inv=>inv.Account.Username.Contains("Admin1"));
            return View(invoices.ToList());
        }
        public IActionResult ByAddress()
        {
            var invoices = _context.Invoices.Include(i => i.Account).Where(inv => inv.Account.Diachi.Contains("TP.HCM"));
            return View(invoices.ToList());
        }
        public IActionResult ByProduct()
        {
            
          var lstProducts = _context.Products.Select(prd => new { Name = prd.Name, TypeName = prd.ProductType.Name});
               
            return View(lstProducts.ToList());
        }


        // GET: Invoices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,IssuedDate,ShippingAddress,ShippingPhone,Total,Status")] Invoices invoices)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoices);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices.FindAsync(id);
            if (invoices == null)
            {
                return NotFound();
            }
            return View(invoices);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,IssuedDate,ShippingAddress,ShippingPhone,Total,Status")] Invoices invoices)
        {
            if (id != invoices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoicesExists(invoices.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(invoices);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoices = await _context.Invoices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoices == null)
            {
                return NotFound();
            }

            return View(invoices);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoices = await _context.Invoices.FindAsync(id);
            _context.Invoices.Remove(invoices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoicesExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
