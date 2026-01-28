using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourismMVC.Models
{
    public class TouristProfile
    {
        [Key]
        public int TouristId { get; set; }

        [Required, StringLength(120)]
        public string FullName { get; set; }

        [StringLength(30)]
        public string ContactNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
