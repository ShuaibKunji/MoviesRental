using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesRental.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        
        [Required(ErrorMessage = "Please enter your name"), MaxLength(30)]
        public string CName { get; set; }

        [Required(ErrorMessage = "Please enter your email address"), MaxLength(30)]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Email entered is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password (at least 8 characters, including letters- both uppercase and lowercase, numbers and symbols)")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Please enter a stronger password")]
        public string Password { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your phone number"), MaxLength(10)]
        //Regex below is a validator for Indian mobile numbers
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please enter a valid Indian mobile number or an alternate number")]
        public string Phone { get; set; }
    }
}