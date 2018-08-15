using System.Collections.Generic;
using CarRent.Models;

namespace CarRent.Models.ViewModel
{
    public class CarListView
    {
        public IEnumerable<Car> Cars { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
