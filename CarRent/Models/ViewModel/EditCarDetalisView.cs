using System.Collections.Generic;
using CarRent.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRent.Models.ViewModel
{
    public class EditCarDetalisView
    {
        public CarDetails CarDetails { get; set; }
        public IList<SelectListItem> LocationList { get; set; }
        public IList<SelectListItem> CarList { get; set; }
    }
}
