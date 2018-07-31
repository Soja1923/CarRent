using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Controllers
{
    public class CarController : Controller
    {
        public IActionResult CarsList()
        {
            return View();
        }

        public IActionResult Car()
        {
            return View();
        }
    }
}