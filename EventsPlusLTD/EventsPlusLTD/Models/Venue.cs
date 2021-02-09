using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus_LTD.Models
{
    //Creates and retrieves the following data from the database very quickly
    [Index(nameof(ID), IsUnique = true)]
    [Index(nameof(StreetAddress))]
    [Index(nameof(City))]
    [Index(nameof(Postcode))]
    [Index(nameof(VenueCapacity))]
    [Index(nameof(VenuePictureOne))]
    [Index(nameof(VenuePictureTwo))]
    [Index(nameof(VenuePictureThree))]
    public class Venue
    {
        public int ID { get; set; }//Returns the ID in the variable and stores the ID into the variable
        [Required(ErrorMessage = "Street Address is required")] //Validates that the field is not null
        //Displays error message usually in red
        [Display(Name = "Street Address")] //Displays the name 'Street Address'
        [Column("StreetAddress")] //Column in venue will be named 'Street Address'
        [StringLength(100, ErrorMessage = "Must be between 5 and 100 characters", MinimumLength = 5)]
        //Validates that a string property value doesn't exceed a specified length limit. 
        //Also specifies the minimum length of the string data allowed in the property.
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "City name is required")]
        [Display(Name = "City")]
        [Column("City")]
        [StringLength(50, ErrorMessage = "Must be between 2 and 50 characters", MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = "Postcode is Required")]
        [Display(Name = "Postcode")]
        [Column("Postcode")]
        [DataType(DataType.PostalCode)] //Specifies the data type of the attribute as a postcode
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Venue capacity is required")]
        [Display(Name = "Venue Capacity")]
        [Column("VenueCapacity")]
        [MaxLength(8, ErrorMessage = "Must be between 1 and 8 digits")] //Specifies the maximum length of the string data allowed in the property 
        [MinLength(1)] //Specifies the minimum length of the string data allowed in the property
        [RegularExpression("^[0-9]*$", ErrorMessage = "Venue capacity must be numeric")]
        //Validates that the property value is only numeric
        public int VenueCapacity { get; set; }

        [Column("VenuePictureOne")]
        [Display(Name = "Venue Picture 1")]
        [DataType(DataType.Upload)] //Generates a file upload input for attribute
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "File is not an image")]
        //Validates that the file upload has to be in a image format
        public byte? VenuePictureOne { get; set; }

        [Column("VenuePictureTwo")]
        [Display(Name = "Venue Picture 2")]
        [DataType(DataType.Upload)]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "File is not an image")]
        public byte? VenuePictureTwo { get; set; }

        [Column("VenuePictureThree")]
        [Display(Name = "Venue Picture 3")]
        [DataType(DataType.Upload)]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "File is not image")]
        public byte? VenuePictureThree { get; set; }

        //Foreign keys 
        public int EventID { get; set; }
        public Event Event { get; set; }

    }
}
