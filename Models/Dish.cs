using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurants.Models.Validation;

namespace Restaurants.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        [MinLength(2,ErrorMessage="Dish Name must have at least 2 characters") ]
        public string DishName {get;set;}
        [Required]
        [Range(0.5,Int32.MaxValue, ErrorMessage="Value must be at least 50 cents")]
        public double Price {get;set;}
        [Required]
        [MinLength(2,ErrorMessage="Please list ingredients in the dish") ]
        public string Ingredients {get;set;}
        
        [MinLength(45,ErrorMessage="Please describe more about the dish") ]
        public string Description {get;set;}
        [Required]
        public string Type {get;set;}
        public DateTime CreateAt {get;set;} = DateTime.Now;
        public DateTime UpdateAt {get;set;} = DateTime.Now;
        
    }
}