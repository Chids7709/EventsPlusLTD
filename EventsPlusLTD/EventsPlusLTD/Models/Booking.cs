using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus_LTD.Models
{
    [Index(nameof(ID), IsUnique = true)]
    [Index(nameof(BookingDate))]
    [Index(nameof(PaymentConfirmed))]
    [Index(nameof(QuantityTickets))]
    [Index(nameof(TotalPrice))]
    public class Booking
    {
        public int ID { get; set; }
        [Required]
        [Column("BookingDate")]
        [Display(Name = "Booking Date")]
        [DataType(DataType.DateTime)]
        public DateTime BookingDate { get; set; }

        [Required]
        [Column("PaymentConfirmed?")]
        [Display(Name = "Payment Confirmed?")]
        [DataType(DataType.Text)]
        public bool PaymentConfirmed { get; set; }

        [Required(ErrorMessage = "Must select quantity of tickets")]
        [Column("Quantityoftickets")]
        [Display(Name = "Quantity of tickets")]
        [RegularExpression("^[0-9]*$")]
        public Quantity QuantityTickets { get; set; }

        [Required]
        [Column("TotalPrice")]
        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public float? TotalPrice { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public int AttendeeID { get; set; }
        public Attendee Attendee { get; set; }
        public int EventID { get; set; }
        public Event Event { get; set; }
    }
    public enum Quantity
    {
        One,
        Two,
        Three,
        Four,
        Five
    }
}
