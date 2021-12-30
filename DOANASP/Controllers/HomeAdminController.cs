using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOANASP.Controllers
{
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {

            if (HttpContext.Request.Cookies.ContainsKey("AccountUsername"))
            {
                ViewBag.AccountUsername = HttpContext.Request.Cookies["AccountUsername"].ToString();
            }
            return View();
        }

    }
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {


            return View();
        }
    }
}
