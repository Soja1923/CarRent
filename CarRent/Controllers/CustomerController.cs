using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Data.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepo repo;
        public CustomerController(ICustomerRepo _repo)
        {
            repo = _repo;
        }

        public ViewResult CustomerList()
             => View(
                 repo.GetAll()
                 .OrderBy(l => l.LastName)
                 .Include(a => a.ApplicationUser)
                 .Include(a => a.Address)
                 );

        public IActionResult Customer(int employeId)
            => View(repo.GetAll()
                .Include(a => a.ApplicationUser)
                .Include(a => a.Address)
                .FirstOrDefault(p => p.Person_ID == employeId));
    }
}
