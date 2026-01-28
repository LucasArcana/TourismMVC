using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TourismMVC.Models
{
    public class Feedback
    {
        [Key, ForeignKey("Booking")]
        public int BookingId { get; set; }   // PK + FK

        public virtual Booking Booking { get; set; }

        [Required, Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}