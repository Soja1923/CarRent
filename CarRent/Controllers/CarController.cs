using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CarRent.Data.Repo;
using CarRent.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    public class CarController : Controller
    {
        private ICarRepo repository;
        public int PageSize = 12;

        public CarController(ICarRepo _repo)
        {
            repository = _repo;
        }

        public ViewResult CarsList(string category, int carPage = 1)
            => View(new CarListView
            {
                Cars = repository.GetAll()
                        .Where(p=>category==null || p.Grade.GradeType.ToString()==category)
                        .Include(c => c.Grade)
                        .OrderBy(p=>p.Car_ID)
                        .Skip((carPage-1)*PageSize)
                        .Take(PageSize),
                PagingInfo=new PagingInfo
                {
                    CurrentPage=carPage,
                    ItemsPerPage=PageSize,
                    TotalItems=repository.GetAll().Count()
                },
                CurrentCategory=category
            });



        public IActionResult Car(int carID)
            => View(repository.GetById(carID));
       
    }
}