using CarRent.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models.ViewModel
{
    public class AddEmploye
    {
        public RegisterViewModel RegisterView { get; set; }
        public Employee Employee { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
