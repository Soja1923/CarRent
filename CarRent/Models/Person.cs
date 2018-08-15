using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    [Table("Person")]
    public class Person
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Person_ID { get; set; }
        [Required(ErrorMessage ="Proszę podać imię.")]
        [StringLength(40)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Proszę podać nazwisko.")]
        [StringLength(65)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Proszę podać PESEL.")]
        [RegularExpression("^\\d{11}$", ErrorMessage ="Podany PESEL jest nieprawidłowy.")]
        public string PESEL { get; set; }

        [ForeignKey("Address_ID")]
        public int? Address_ID { get; set; }
        public virtual Address Address { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
