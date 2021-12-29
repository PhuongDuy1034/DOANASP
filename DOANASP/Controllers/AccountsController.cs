using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DOANASP.Data;
using DOANASP.Models;
using Microsoft.AspNetCore.Http;

namespace DOANASP.Controllers
{
    public class AccountsController : Controller
    {
        private readonly DoanASPcontext _context;

        public AccountsController(DoanASPcontext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> ByAddress()
        {
            var byaddress = _context.Accounts.Where(acc => acc.Diachi.Contains("TP.HCM"));
            return View(await byaddress.ToListAsync());
            //   return View(await _context.Accounts.ToListAsync());
        }
        public async Task<IActionResult> ByGmail()
        {
            var byaddress = _context.Accounts.Where(acc => acc.Email.Contains("gmail"));
            return View(await byaddress.ToListAsync());
            //   return View(await _context.Accounts.ToListAsync());
        }
        public async Task<IActionResult> Search(string search)
        {
            ViewData["Get"] = search;

            var searchr = from x in _context.Accounts select x;
            if(!String.IsNullOrEmpty(search))
            {
                searchr = searchr.Where(x => x.Username.Contains(search) || x.Email.Contains(search)|| x.Phone.Contains(search)||x.Diachi.Contains(search)||x.Fullname.Contains(search));

            }
            return View (await searchr.AsNoTracking().ToListAsync());
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Accounts.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            Account account = _context.Accounts.Where(a => a.Username == Username && a.Password == Password ).FirstOrDefault();
            if (account != null)
            {
                CookieOptions cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(7)
                };
                HttpContext.Response.Cookies.Append("AccountID", account.Id.ToString(), cookieOptions);
                HttpContext.Response.Cookies.Append("AccountUsername", account.Username.ToString(), cookieOptions);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Sai Rồi Bạn Ơi!";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Append("AccountID", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            HttpContext.Response.Cookies.Append("AccountUsername", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Fullname,Email,Phone,NgSinh,IsAdmin,Avatar,Status,Diachi")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,Fullname,Email,Phone,NgSinh,IsAdmin,Avatar,Status,Diachi")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
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
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
