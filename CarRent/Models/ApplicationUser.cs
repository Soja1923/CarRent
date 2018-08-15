
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [RegularExpression("/^[a-z\\d]+[\\w\\d.-]*@(?:[a-z\\d]+[a-z\\d-]+\\.){1,5}[a-z]{2,6}$/i",
            ErrorMessage = "Podany adres e-mail jest nieprawidłowy.")]
        public override string Email{get; set;}
        [Required(ErrorMessage = "Proszę podać numer telfonu.")]
        [RegularExpression("^(?:\\(?\\+?48)?(?:[-\\.\\(\\)\\s]*(\\d)){9}\\)?$",
            ErrorMessage = "Podany numer telefonu jest nieprawidłowy.")]
        public override string PhoneNumber { get; set; }

        public virtual Person Person { get; set; }
    }
}
