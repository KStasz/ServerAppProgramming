using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ServerAppProgramming.Data;
using ServerAppProgramming.Models;

namespace ServerAppProgramming.Components
{
    public partial class Verification : ComponentBase
    {
        [Inject]
        public ApplicationDbContext _dbContext { get; set; }

        public List<SummaryOrder> listOrder { get; set; }

        protected override void OnInitialized()
        {
            listOrder = ReadData();
        }

        private List<SummaryOrder> ReadData()
        {
            List<ServerAppProgramming.Models.Order> locallist = _dbContext.Order.Where(x => x.IsInWeryfication == true).ToList();
            listOrder = new List<SummaryOrder>();
            foreach (var item in locallist)
            {
                listOrder.Add(new SummaryOrder()
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    meal = _dbContext.Meals.Where(x => x.Id == item.MealId).First(),
                    restaurant = _dbContext.Restaurants.Where(x => x.Id == item.RestaurantId).First(),
                    date = item.CreationDate,
                    Username = _dbContext.Users.Where(x => x.Id == item.UserId).First().UserName
                });
            }
            return listOrder;
        }
    }
}
