using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeledocTest.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Success(Object obj)
        {
            return View(obj);
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
