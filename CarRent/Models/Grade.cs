using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    [Table("Grade")]
    public class Grade
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Grade_ID { get; set; }
        [Required]
        public GradeType GradeType { get; set;}
        [Required(ErrorMessage = "Proszę podać cene wypożyczenia za dzień.")]
        [Range(0, double.MaxValue, ErrorMessage ="Wartość musi być większa od 0.")]
        public double PricePerDay { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
    public enum GradeType
    {
        A,B,C,D,Premium, SUV,BUS
    }
}
