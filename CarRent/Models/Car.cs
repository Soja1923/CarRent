using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    [Table("Car")]
    public class Car
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Car_ID { get; set; }
        [Required(ErrorMessage = "Proszę podać model auta.")]
        [StringLength(30)]
        public string Model { get; set; }
        [Required(ErrorMessage = "Proszę podać marke auta.")]
        [StringLength(30)]
        public string Mark { get; set; }
        [Required(ErrorMessage ="Proszę wybrać zdjęcie.")]
        public string Img { get; set; }
        [Required]
        public Gearbox GearboxType { get; set; }
        [Required]
        public FuelType Fuel { get; set; }
        [Required]
        [Range(2, 10)]
        public int NumberOfSeats { get; set; }
        [Required(ErrorMessage = "Proszę podać opis auta.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Proszę podać typ nadwozja.")]
        public BodyType Body { get; set; }
        [Required(ErrorMessage = "Proszę podać pojemność silnika.")]
        public double EngineCapacity { get; set; }
        [Required(ErrorMessage = "Prosze podać rok.")]
        public int Year { get; set; }

        public int GradeID { get; set; }
        [ForeignKey("GradeID")]
        public virtual Grade Grade { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<CarDetails> CarsDetails { get; set; } = new HashSet<CarDetails>();
        public virtual ICollection<UserRating> UserRatings { get; set; } = new HashSet<UserRating>();
    }

    public enum Gearbox
    {
        Automat, Manual
    }
    public enum FuelType
    {
        Benzyna, Gaz, Diesel
    }
    public enum BodyType
    {
        SUV, VAN, Sedan, Kombi, Hatchback, PickUp
    }
}
