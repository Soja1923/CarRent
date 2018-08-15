using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    [Table("UserRating")]
    public class UserRating
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRating_ID { get; set; }
        public string Comment { get; set; }
        public bool RatingPositive { get; set; } = false;
        public bool RatingNegative { get; set; } = false;

        [Required]
        public int CarID { get; set; }
        [ForeignKey("CarID")]
        public virtual Car Car { get; set; }
        [Required]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<UserRating> UserRatings { get; set; } = new HashSet<UserRating>();
    }
}
