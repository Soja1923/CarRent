using System;
using System.Collections.Generic;
using System.Linq;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc;
using CarRent.Data.Repo;
using Microsoft.EntityFrameworkCore;
using CarRent.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRent.Controllers
{
    public class CarDetalisController : Controller
    {
        private ICarDetalistRepo repo;
        private ILocationRepo repoLocation;
        private ICarRepo repoCar;

        public CarDetalisController(ICarDetalistRepo _repo, ILocationRepo _locationRepo, ICarRepo _carRepo)
        {
            repo = _repo;
            repoLocation = _locationRepo;
            repoCar = _carRepo;
        }

        public ViewResult CarDetalisList()
             => View(
                 repo.GetAll()
                 .OrderBy(l=>l.RegistrationNumber)
                 .Include(a => a.Car)
                 .Include(a=> a.Location.Address)
                 );

        
        List<SelectListItem> SelectListItemsCar(EditCarDetalisView vm)
        {
            var carList = repoCar.GetAll().ToList();
            var carListSelected = new List<SelectListItem>();
            foreach (var item in carList)
            {
                string id = item.Car_ID.ToString();
                string carText = item.ToString();
                carListSelected.Add(new SelectListItem { Text = carText, Value = id });
            }

            return carListSelected;
        }
        List<SelectListItem> SelectListItemsLocation(EditCarDetalisView vm)
        {
            var locationList = repoLocation.GetAll().Include(l => l.Address).Distinct().ToList();
            var locationListSelected = new List<SelectListItem>();
            foreach (var item in locationList)
            {
                string addresText = item.Address.ToString();
                string id = item.Location_ID.ToString();
                locationListSelected.Add(new SelectListItem { Text = addresText, Value = id });
            }
            return locationListSelected;
        }

        public ViewResult Edit(int carDetalisID)
        {
            var vm = new EditCarDetalisView();
            vm.CarDetails = repo.GetAll().FirstOrDefault(l => l.CarDetailsID == carDetalisID);
            vm.LocationList = SelectListItemsLocation(vm);
            vm.CarList = SelectListItemsCar(vm);
            return View(vm);
        }
            
        public ViewResult Create()
        {
            var vm = new EditCarDetalisView();
            vm.CarDetails = new CarDetails();
            vm.LocationList = SelectListItemsLocation(vm);
            vm.CarList = SelectListItemsCar(vm);
            return View("Edit", vm);
        }

        [HttpPost]
        public IActionResult Edit(CarDetails carDetails)
        {
            if (ModelState.IsValid)
            {
                repo.Save(carDetails);
                TempData["message"] = $"Zapisano zmiany.";
                return RedirectToAction("CarDetalisList");
            }
            else
            {
                return View(carDetails);
            }
        }
    }

}