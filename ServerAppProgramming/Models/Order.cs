using System;
using System.ComponentModel.DataAnnotations;

namespace ServerAppProgramming.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int MealId { get; set; }
        public int RestaurantId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
