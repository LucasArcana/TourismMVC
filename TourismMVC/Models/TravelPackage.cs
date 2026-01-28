using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TourismMVC.Models;

namespace TourismMVC.Models
{
    public class TravelPackage
    {
        [Key]
        public int PackageId { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; }

        [Required, StringLength(1200)]
        public string Description { get; set; }

        [Required, StringLength(120)]
        public string Destination { get; set; }

        [StringLength(300)]
        public string ImagePath { get; set; }  // keep 1 image only (easy)

        [Required]
        public int AgencyId { get; set; }

        public virtual AgencyProfile AgencyProfile { get; set; }

        public virtual ICollection<TourSchedule> TourSchedules { get; set; }
    }
}



