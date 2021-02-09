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
    [Index(nameof(CreationDate))]
    [Index(nameof(ModifiedDate))]
    [Index(nameof(EventName))]
    [Index(nameof(EventType))]
    [Index(nameof(Description))]
    [Index(nameof(TicketPrice))]
    [Index(nameof(StartDateTime))]
    [Index(nameof(EndDateTime))]
    [Index(nameof(RegistrationEndDate))]
    [Index(nameof(EventStatus))]
    [Index(nameof(EventPicture))]
    public class Event
    {
        public int ID { get; set; }

        [Required]
        [Column("CreationDate")]
        [Display(Name = "Creation Date")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [Required]
        [Column("ModifiedDate")]
        [Display(Name = "Modified Date")]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }

        public Event()
        {
            this.CreationDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
        }

        [Required(ErrorMessage = "Must provide a name for your event")]
        [Column("EventName")]
        [Display(Name = "Event Name")]
        // Allow up to 50 uppercase and lowercase characters and spaces. 
        [RegularExpression(@"^[a-zA-Z\s]{1,50}$", ErrorMessage = " Up to 50 uppercase and lowercase characters are allowed.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Must select an event type")]
        [Column("EventType")]
        [Display(Name = "Event Type")]
        [DataType(DataType.Text)]
        public Type EventType { get; set; }

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(1000, ErrorMessage = "Must be between 20 and 1000 characters", MinimumLength = 20)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Must provide a ticket price")]
        [Column("TicketPrice")]
        [Display(Name = "Ticket Price")]
        [DataType(DataType.Currency)]
        [Range(typeof(Decimal), "0", "9999999", ErrorMessage = "Price must be a decimal/number between {1} and {2}.")]
        public float TicketPrice { get; set; }

        [Required(ErrorMessage = "Must provide a start date and time")]
        [Column("StartDateandTime")]
        [Display(Name = "Start Date and Time")]
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [Required(ErrorMessage = "Must provide a end date and time")]
        [Column("EndDateandTime")]
        [Display(Name = "End Date and Time")]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        [Required(ErrorMessage = "Must provide a registration end date")]
        [Column("RegistrationEndDate")]
        [Display(Name = "Registration End Date")]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationEndDate { get; set; }

        [Required(ErrorMessage = "Must select a status")]
        [Column("EventStatus")]
        [Display(Name = "Event Status")]
        [DataType(DataType.Text)]
        public Status EventStatus { get; set; }

        [Column("EventPictureOne")]
        [Display(Name = "Event Picture")]
        [DataType(DataType.Upload)]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "File is not an image")]
        public byte? EventPicture { get; set; }

        public int OrganizerID { get; set; }
        public Organizer Organizer { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Venue> Venues { get; set; }
    }
    public enum Type
    {
        Business, Food_and_Drink, Health, Music, Charity_and_Causes, Community, Family_and_Education, Fashion, Film_and_Media, Hobbies, Home_and_Lifestyle, Performing_and_Visual_Arts, Government, Spirituality, School_Activities, Science_and_Tech, Holiday, Sports_and_Fitness, Travel_and_Outdoor, Other
    }
    public enum Status
    {
        Open_To_Registrations, Closed_To_Registrations, Cancelled
    }
}

