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
    [Index(nameof(NameOnCard))]
    [Index(nameof(CardNumber), IsUnique = true)]
    [Index(nameof(CardType))]
    [Index(nameof(ExpiryDate))]
    [Index(nameof(SecurityCode))]
    public class Payment
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Must provide name on card")]
        [Column("Nameoncard")]
        [Display(Name = "Name on card")]
        [StringLength(50)]
        public string NameOnCard { get; set; }

        [Column("CardNumber")]
        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Card number is required")]
        [DataType(DataType.CreditCard)]
        public long CardNumber { get; set; }

        [Required(ErrorMessage = "Must select a card type")]
        [Column("CardType")]
        [Display(Name = "Card Type")]
        [DataType(DataType.Text)]
        public CardType CardType { get; set; }

        [Required(ErrorMessage = "Must provide expiry date on card")]
        [Column("ExpiryDate")]
        [Display(Name = "Expiry Date")]
        [DisplayFormat(DataFormatString = "{MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "Must provide security code on the back of the card")]
        [Column("SecurityCode")]
        [Display(Name = "Security Code")]
        [MaxLength(3, ErrorMessage = "Must be 3 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Security code must be numeric")]
        public int SecurityCode { get; set; }

        public int BookingID { get; set; }
        public Booking Booking { get; set; }
    }
    public enum CardType
    {
        Unknown = 0,
        MasterCard = 1,
        VISA = 2,
        Amex = 3,
        Discover = 4,
        DinersClub = 5,
        JCB = 6,
        enRoute = 7
    }
}

