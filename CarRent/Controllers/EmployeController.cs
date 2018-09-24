using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRent.Data.Repo;
using Microsoft.EntityFrameworkCore;
using CarRent.Models;
using CarRent.Models.ViewModel;

namespace CarRent.Controllers
{
    public class EmployeController : Controller
    {
        private IEmployeRepo repo;
        public EmployeController(IEmployeRepo _repo)
        {
            repo = _repo;
        }
       
        public ViewResult EmployeesList()
             => View(
                 repo.GetAll()
                 .OrderBy(l => l.LastName)
                 .Include(a => a.ApplicationUser)
                 .Include(a=>a.Address)
                 .Include(a=>a.Location.Address)
                 );

        public ViewResult EmployeesListByLocation(int locationId)
            => View(
                repo.GetAll()
                .Where(l=>l.LocationID==locationId)
                .OrderBy(l => l.LastName)
                .Include(a => a.ApplicationUser)
                .Include(a => a.Address)
                .Include(a => a.Location.Address)
                );

        public IActionResult Employe(int employeId)
            => View(repo.GetAll()
                .Include(a => a.ApplicationUser)
                .Include(a => a.Address)
                .Include(a => a.Location.Address)
                .FirstOrDefault(p => p.Person_ID == employeId));

             
    }

}

