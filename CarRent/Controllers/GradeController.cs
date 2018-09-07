using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarRent.Data.Repo;
using CarRent.Models;

namespace CarRent.Controllers
{
    public class GradeController : Controller
    {
        private IGradeRepo repo;
        public GradeController(IGradeRepo _repo)
        {
            repo = _repo;
        }

        public ViewResult GradeList()
            => View(
                repo.GetAll()
                .OrderBy(l => l.GradeType.ToString()));


        public ViewResult Edit(int gradeID) =>
             View(
                repo.GetAll()
                .FirstOrDefault(l => l.Grade_ID == gradeID));

        [HttpPost]
        public IActionResult Edit(Grade grade)
        {
            if (ModelState.IsValid)
            {
                repo.Save(grade);
                TempData["message"] = $"Zapisano zmiany.";
                return RedirectToAction("GradeList");
            }
            else
            {
                return View(grade);
            }
        }
    }
}