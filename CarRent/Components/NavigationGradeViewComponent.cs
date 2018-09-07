using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CarRent.Data.Repo;

namespace CarRent.Components
{
    public class NavigationGradeViewComponent : ViewComponent
    {
        private ICarRepo repo;

        public NavigationGradeViewComponent(ICarRepo _repo)
        {
            repo = _repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGrade = RouteData?.Values["category"];
            return View(repo.GetAll()
                .Select(x=>x.Grade.GradeType.ToString())
                .Distinct()
                .OrderBy(x=>x));
        }
    }
}
