using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarRent.Models
{
    [Table("Address")]
    public class Address
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Address_ID { get; set; }
        [Required(ErrorMessage ="Proszę podać ulice.")]
        [StringLength(50)]
        public string Street { get; set; }
        [Required(ErrorMessage ="Proszę podać numer domu.")]
        [StringLength(10)]
        public string Number { get; set; }
        [Required(ErrorMessage ="Proszę podać miasto.")]
        [StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage ="Proszę podać kod pocztowy.")]
        [RegularExpression("[0-9]{2}-[0-9]{3}",
           ErrorMessage = "Podany kod pocztowy jest nieprawidłowy.")]
        [StringLength(6)]
        public string PostalCode { get; set; }

        public virtual Location Location { get; set; }
        public virtual Person Person { get; set; }


        public override string ToString()
        {
            return City + " " + PostalCode + " " +Street + " " +Number;
        }
    }
}
