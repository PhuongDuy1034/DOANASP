using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOANASP.Controllers
{
    public class HomeAdminController : Controller
    {
        public IActionResult Indexadmin()
        {
            return View();
        }
        public IActionResult Indextest()
        {
            return View();
        }
    }
}
