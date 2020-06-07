﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ServerAppProgramming.Models
{
    public class Meals
    {
        [Key]
        public int Id { get; set; }
        public string MealName { get; set; }
        public int CategoryId { get; set; }
        public int RestaurantId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
