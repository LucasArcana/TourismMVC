using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourismMVC.Models
{
    public class TourSchedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AvailableDate { get; set; }

        [Required, Range(1, 60)]
        public int DurationDays { get; set; }

        [Required, Range(0.0, 999999.0)]
        public decimal Price { get; set; }

        [Required, Range(1, 100)]
        public int GroupSizeLimit { get; set; }

        [Required]
        public int PackageId { get; set; }

        public virtual TravelPackage TravelPackage { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}