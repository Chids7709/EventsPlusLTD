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
    [Index(nameof(OrgLastName))]
    [Index(nameof(OrgFirstName))]
    [Index(nameof(OrgGender))]
    [Index(nameof(OrgDoB))]
    [Index(nameof(OrgPhoneNumber))]
    [Index(nameof(OrgEmail), IsUnique = true)]
    [Index(nameof(OrgStreetAddress))]
    [Index(nameof(OrgCity))]
    [Index(nameof(OrgPostcode))]
    public class Organizer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You must provide your last name")]
        [Column("LastName")]
        [Display(Name = "Last Name")]
        // Allow up to 50 uppercase and lowercase characters and spaces. 
        [RegularExpression(@"^[a-zA-Z\s]{1,50}$", ErrorMessage = " Up to 50 uppercase and lowercase characters are allowed.")]
        public string OrgLastName { get; set; }

        [Required(ErrorMessage = "You must provide your first name")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        // Allow up to 50 uppercase and lowercase characters and spaces. 
        [RegularExpression(@"^[a-zA-Z\s]{1,50}$", ErrorMessage = " Up to 50 uppercase and lowercase characters are allowed.")]

        public string OrgFirstName { get; set; }

        [Required(ErrorMessage = "You must select your gender")]
        [Column("Gender")]
        [Display(Name = "Gender")]
        [DataType(DataType.Text)]
        public OrgGender OrgGender { get; set; }

        [Required(ErrorMessage = "You must provide your date of birth")]
        [Column("DoB")]
        [Display(Name = "DoB")]
        [DataType(DataType.Date)]
        public DateTime OrgDoB { get; set; }

        [Required(ErrorMessage = "You must provide your phone number")]
        [Column("PhoneNumber")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string OrgPhoneNumber { get; set; }

        [Display(Name = "Email address")]
        [Column("EmailAddress")]
        [Required(ErrorMessage = "The email address is required")]
        [DataType(DataType.EmailAddress)]
        public string OrgEmail { get; set; }

        [Required(ErrorMessage = "Street Address is required")]
        [Display(Name = "Street Address")]
        [Column("StreetAddress")]
        [StringLength(100, ErrorMessage = "Must be between 5 and 100 characters", MinimumLength = 5)]
        public string OrgStreetAddress { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [Display(Name = "City")]
        [Column("City")]
        [StringLength(50, ErrorMessage = "Must be between 2 and 50 characters", MinimumLength = 2)]
        public string OrgCity { get; set; }

        [Required(ErrorMessage = "Postcode is Required")]
        [Display(Name = "Postcode")]
        [Column("Postcode")]
        [DataType(DataType.PostalCode)]
        public string OrgPostcode { get; set; }

        public ICollection<Event> Events { get; set; }
    }
    public enum OrgGender
    {
        Male, Female
    }
    //Numbers starting 08, 09 and 070 are special price numbers, and would not generally be given as private numbers, so can be excluded if validating a private number.
    //07 numbers are mobile(except 070; see above) so can be excluded if you're specifically validating for a landline.
}
