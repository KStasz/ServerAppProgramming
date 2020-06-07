using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using ServerAppProgramming.Data;

namespace ServerAppProgramming.Components
{
    public partial class Restaurants : ComponentBase
    {
        [Inject]
        public ApplicationDbContext _dbContext { get; set; }

        public List<ServerAppProgramming.Models.Restaurants> RestaurantsList { get; set; }

        protected override void OnInitialized()
        {
            RestaurantsList = _dbContext.Restaurants.ToList();
        }
    }
}
