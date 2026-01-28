using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourismMVC.Models
{
    public enum BookingStatus { Pending, Confirmed, Completed, Cancelled }
    public enum PaymentStatus { Pending, Paid }

    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int TouristId { get; set; }
        public virtual TouristProfile TouristProfile { get; set; }

        [Required]
        public int ScheduleId { get; set; }
        public virtual TourSchedule TourSchedule { get; set; }

        [Required, Range(1, 100)]
        public int ParticipantsCount { get; set; }

        [Required]
        public BookingStatus BookingStatus { get; set; } = BookingStatus.Pending;

        [Required]
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual Feedback Feedback { get; set; }
    }
}