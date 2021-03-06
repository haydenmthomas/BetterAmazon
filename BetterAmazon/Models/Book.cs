﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetterAmazon.Models
{
    //Established Book class
    public class Book
    {
        //Sets BookID as Key; All properties are required
        [Key]
        [Required]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        //Split up firstname and lastname of the author
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        //Sets the format for the ISBN numbers for books entered into the database
        [RegularExpression(@"^[0-9]{3}-[0-9]{10}$", 
            ErrorMessage = "Please enter in a valid ISBN in the format of '###-##########'")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        //Adds the number of pages for each book
        [Required]
        public int NumPages { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
