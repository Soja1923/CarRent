using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    [Table("CarDetails")]
    public class CarDetails
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarDetailsID { get; set; }
        [Required(ErrorMessage = "Proszę podać numer rejestracyjny.")]
        public string RegistrationNumber { get; set; }
        [Required]
        public StateType State { get; set; }
        public string Comments { get; set; }

        [Required]
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
        [Required]
        public int LocationID { get; set; }
        [ForeignKey("LocationID")]
        public virtual Location Location { get; set; }
    }
    public enum StateType
    {
        Sprawny, Uszkodzony
    }
}
