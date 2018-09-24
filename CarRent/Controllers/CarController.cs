using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CarRent.Data.Repo;
using CarRent.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CarRent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace CarRent.Controllers
{
    public class CarController : Controller
    {
        private readonly IHostingEnvironment environment;
        private ICarRepo repository;
        private IGradeRepo repoGrade;
        public int PageSize = 12;

        public CarController(ICarRepo _repo, IGradeRepo _repograde, IHostingEnvironment _environment)
        {
            repository = _repo;
            repoGrade = _repograde;
            environment = _environment;
        }

        public ViewResult CarsList(string category, int carPage = 1)
            => View(new CarListView
            {
                Cars = repository.getCarByGrade(repository.GetAll(),  category)
                        .Include(c => c.Grade)
                        .OrderBy(p => p.Car_ID)
                        .Skip((carPage - 1) * PageSize)
                        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = carPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.GetAll().Count() :
                        repository.getCarByGrade(repository.GetAll(), category).Count()
                },
                CurrentCategory = category
            });

        public IActionResult Car(int carId)
            => View(repository.GetAll().Include(g=>g.Grade).FirstOrDefault(p=>p.Car_ID==carId));
       
        public ViewResult CarsListAdmin(string category, int carPage = 1)
             => View(new CarListView
                {
                    Cars = repository.getCarByGrade(repository.GetAll(), category)
                        .Include(c => c.Grade)
                        .OrderByDescending(p => p.Car_ID)
                        .Skip((carPage - 1) * PageSize)
                        .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = carPage,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                        repository.GetAll().Count() :
                        repository.GetAll().Where(p => p.Grade.GradeType.ToString() == category).Count()
                    },
                    CurrentCategory = category
                });
       
        public ViewResult Edit(int carID) =>
            View(new EditCarView
            {
                Car=repository.GetAll()
                .FirstOrDefault(p => p.Car_ID == carID),
                GradeList=repoGrade.GetAll().Distinct().ToList()
            });

        public ViewResult Create() => View("Edit", 
            new EditCarView
            {
                Car=new Car(),
                GradeList= repoGrade.GetAll().Distinct().ToList()
            });

        [HttpPost]
        public async Task<IActionResult> Edit(Car car, IFormFile pic)
        {
            if (ModelState.IsValid)
            {
                if (pic != null)
                {
                    int carID;
                    if (car.Car_ID == 0) { carID = repository.GetAll().Count() + 1; }
                    else { carID = car.Car_ID; }
                    string uploadPath = Path.Combine(environment.WebRootPath, "uploads");
                    Directory.CreateDirectory(Path.Combine(uploadPath, carID.ToString()));

                    string filename = pic.FileName;
                    if (filename.Contains('\\'))
                    {
                        filename = filename.Split('\\').Last();
                    }
                    using (FileStream fs = new FileStream(Path.Combine(uploadPath, carID.ToString(), filename), FileMode.Create))
                    {
                        await pic.CopyToAsync(fs);
                    }
                    car.Img = filename;
                }
                repository.Save(car);
                    TempData["message"] = $"Zapisano zmiany.";
                    return RedirectToAction("CarsListAdmin");
            }
            else
            {
                return View(new EditCarView
                {
                    Car = car,
                    GradeList = repoGrade.GetAll().Distinct().ToList()
                });
            }
        }
    }
}