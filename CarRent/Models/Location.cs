using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    [Table("Location")]
    public class Location
    { 
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Location_ID { get; set; }

        [Required(ErrorMessage = "Proszę podać numer telfonu.")]
        [RegularExpression("^(?:\\(?\\+?48)?(?:[-\\.\\(\\)\\s]*(\\d)){9}\\)?$",
           ErrorMessage = "Podany numer telefonu jest nieprawidłowy.")]
        public string Phone_Number { get; set; }

        [Required(ErrorMessage = "Proszę podać adres e-mail.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
          ErrorMessage = "Podany adres e-mail jest nieprawidłowy.")]
        public string E_mail { get; set; }

        [ForeignKey("Address_ID")]
        public int? Address_ID { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        public virtual ICollection<CarDetails> CarDetails { get; set; } = new HashSet<CarDetails>();
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
