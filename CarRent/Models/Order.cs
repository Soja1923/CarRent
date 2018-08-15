using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    [Table("Order")]
    public class Order
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }
        [Required(ErrorMessage ="Proszę podać datę wyporzyczenia auta.")]
        public DateTime DateStart { get; set; }
        [Required(ErrorMessage ="Proszę podać datę zwrotu auta.")]
        public DateTime DateEnd { get; set; }
        public State State { get; set; }

        [Required]
        public int Person_ID { get; set; }
        [ForeignKey(" Person_ID")]
        public virtual Customer Customer { get; set; }
        [Required]
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
    }

    public enum State
    {
        Oddany, Zarezerwowany, Wypożyczony
    }
}
