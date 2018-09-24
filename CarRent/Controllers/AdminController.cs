using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Data.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    public class AdminController : Controller
    {
        private ILocationRepo repo;

        public AdminController(ILocationRepo _repo)
        {
            repo = _repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LocationIndex(int locationId)
        {
            return View(
               repo.GetAll()
                .Include(a => a.Address)
               .FirstOrDefault(l => l.Location_ID == locationId));
        }
    }
}