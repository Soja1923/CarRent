using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models.ViewModel
{
    public class OrderView
    {
        public Order Order { get; set; }
        public CarDetails CarDetails { get; set; }
        public string RegisterNumber{ get; set; }
    }
}
