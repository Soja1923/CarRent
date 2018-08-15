using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class Employee:Person
    {
        [Required]
        public int? LocationID { get; set; }
        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }
    }
}
