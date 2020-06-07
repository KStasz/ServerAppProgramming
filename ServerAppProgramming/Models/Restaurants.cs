using System;
using System.ComponentModel.DataAnnotations;

namespace ServerAppProgramming.Models
{
    public class Restaurants
    {
        [Key]
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
