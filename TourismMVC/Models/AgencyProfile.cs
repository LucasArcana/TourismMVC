using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourismMVC.Models
{
    public class AgencyProfile
    {
        [Key]
        public int AgencyId { get; set; }

        [Required, StringLength(120)]
        public string AgencyName { get; set; }

        [StringLength(500)]
        public string ServicesOffered { get; set; }

        [StringLength(800)]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }   // temporary


        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<TravelPackage> TravelPackages { get; set; }
    }
}
