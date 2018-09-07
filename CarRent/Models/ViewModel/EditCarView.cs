using System.Collections.Generic;
using CarRent.Models;
using System.Linq;

namespace CarRent.Models.ViewModel
{
    public class EditCarView
    {
        public Car Car { get; set; }
        public IList<Grade> GradeList { get; set; }
    }
}
