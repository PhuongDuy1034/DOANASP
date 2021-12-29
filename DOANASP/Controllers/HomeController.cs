using DOANASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DOANASP.Data;

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

       
        public IActionResult Index()
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
