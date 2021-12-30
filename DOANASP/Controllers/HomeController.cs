using DOANASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DOANASP.Data;
using Microsoft.AspNetCore.Http;

namespace DOANASP.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private readonly DoanASPcontext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       


        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("AccountUsername"))
            {
                ViewBag.AccountUsername = HttpContext.Request.Cookies["AccountUsername"].ToString();
            }    
            return View();
        }
        //public async Task<IActionResult> Index()
       // {
         //   return View(_context);
       // }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }
    public class LoginController : Controller
    {
        private readonly DoanASPcontext _context;
        public LoginController(DoanASPcontext context)
        {
            _context = context;
        }

        public IActionResult IndexAdmin()
        {

           

            return View();
        }
        public async Task<IActionResult> Login(string Username, string Password)
        {
            Account account = _context.Accounts.Where(a => a.Username == Username && a.Password == Password&& a.IsAdmin==true).FirstOrDefault();
            if (account != null)
            {
                CookieOptions cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(7)
                };
                HttpContext.Response.Cookies.Append("AccountID", account.Id.ToString(), cookieOptions);
                HttpContext.Response.Cookies.Append("AccountUsername", account.Username.ToString(), cookieOptions);
                return RedirectToAction("Index", "HomeAdmin");
            }
            else
            {
                ViewBag.error = "Sai Rồi Bạn Ơi!";
                return View("IndexAdmin");
            }
        }
       
        public IActionResult LogoutAdmin()
        {
            HttpContext.Response.Cookies.Append("AccountID", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            HttpContext.Response.Cookies.Append("AccountUsername", "", new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            return RedirectToAction("Index", "Home");
        }
        public IActionResult IndexUser()
        {
            return View();
        }


    }
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }


}
