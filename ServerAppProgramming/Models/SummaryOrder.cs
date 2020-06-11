using System;
namespace ServerAppProgramming.Models
{
    public class SummaryOrder
    {
        public int  Id { get; set; }
        public Meals meal { get; set; }
        public Restaurants restaurant { get; set; }
        public Categories category { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; }
        public bool IsInEdit { get; set; } = true;
        public bool IsInWeryfication { get; set; }
        public DateTime date { get; set; }
    }
}
