using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CarRent.Data.Repo;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepo repo;
        public LocationController(ILocationRepo _repo)
        {
            repo = _repo;
        }
        
        public ViewResult LocationList() 
            => View(
                repo.GetAll()
                .OrderBy(l => l.Location_ID)
                .Include(a => a.Address));

        public ViewResult LocationListAdmin()
            => View(
                repo.GetAll()
                .OrderBy(l=>l.Address.City)
                .Include(a=>a.Address)
                );

        public ViewResult Edit(int locationID)=>
             View(
                repo.GetAll()
                 .Include(a=>a.Address)
                .FirstOrDefault(l => l.Location_ID == locationID));

        public ViewResult Create() => View("Edit", new Location());

        [HttpPost]
        public IActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                repo.Save(location);
                TempData["message"] = $"Zapisano zmiany.";
                return RedirectToAction("LocationListAdmin");
            }
            else
            {
                return View(location);
            }
        }
    }
    

}