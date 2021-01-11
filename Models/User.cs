using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurants.Models.Validation;

namespace Restaurants.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [MinLength(2,ErrorMessage="First Name must have at least 2 characters") ]
        public string FirstName {get;set;}
        [Required]
        [MinLength(2,ErrorMessage="Last Name must have at least 2 characters") ]
        public string LastName {get;set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegexEmail]
        public string Email{get;set;}
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegexPhone]
        public string Phone{get;set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage="Password need to be at least 8 charcters")]
        [RegexPass]
        public string Password {get;set;}
        [Required]
        public string Role {get;set;} = "Guest";
        public DateTime CreateAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string CFPass{get;set;}
    }
}