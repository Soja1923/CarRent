using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRent.Data.Repo;
using CarRent.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using CarRent.Models;

namespace CarRent.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepo repository;
        private ICarDetalistRepo repositoryCarDetal;
        public int PageSize = 12;

        public OrderController(IOrderRepo _repo, ICarDetalistRepo _repositoryCarDetal)
        {
            repository = _repo;
            repositoryCarDetal = _repositoryCarDetal;
        }

        public ViewResult OrderList(int carPage = 1)
        => View(new OrderListView
        {
            Orders = repository.GetAll()
                    .Include(c => c.Customer)
                    .Include(c=>c.Car)
                    .OrderBy(p => p.DateEnd)
                    .Skip((carPage - 1) * PageSize)
                    .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = carPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.GetAll().Count()
            },
        });

        public ViewResult OrderListByLocation(string location, int carPage = 1)
        {
            return View(new OrderListView
            {
                Orders = repository.GetAll()
                    .Where(l => l.LocationEnd == location)
                    .Include(c => c.Customer)
                    .Include(c => c.Car)
                    .OrderBy(p => p.DateEnd)
                    .Skip((carPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = carPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.GetAll().Count()
                }
            });
        }
        public ViewResult OrderHistory(int customerID, int carPage = 1)
        {
            return View(new OrderListView
            {
                Orders = repository.GetAll()
                    .Where(l => l.Customer.Person_ID == customerID)
                    .Include(c => c.Customer)
                    .Include(c => c.Car)
                    .OrderBy(p => p.DateEnd)
                    .Skip((carPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = carPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.GetAll().Count()
                }
            });
        }
        public IActionResult Order(int orderId, string registerNumber)
           => View(new OrderView()
           {
               Order = repository.GetAll()
               .Include(c => c.Customer)
               .Include(c => c.Car)
               .Include(c => c.Car.Grade)
               .FirstOrDefault(c => c.Order_ID == orderId),

               CarDetails= repositoryCarDetal.GetAll()
               .Include(c=>c.Location.Address)
               .Where(x => x.RegistrationNumber == registerNumber).FirstOrDefault()
               
           });
        public ViewResult EditState(int orderId) =>
             View(
                repository.GetAll()
                 .Include(c => c.Customer)
                 .Include(c => c.Car)
                .FirstOrDefault(l => l.Order_ID == orderId));
        [HttpPost]
        public IActionResult EditState(Order order)
        {
            if (ModelState.IsValid)
            {
                repository.EditState(order);
                TempData["message"] = $"Zapisano zmiany.";
                return RedirectToAction("OrderList");
            }
            else
            {
                return View(order);
            }
        }
    }
}