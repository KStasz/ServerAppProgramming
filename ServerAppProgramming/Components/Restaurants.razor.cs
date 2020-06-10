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

        #region Properties
        public List<ServerAppProgramming.Models.Restaurants> RestaurantsList { get; set; }

        public ComponentsState State { get; set; } = ComponentsState.None;

        public ServerAppProgramming.Models.Restaurants selectedRestaurant { get; set; }

        #endregion

        protected override void OnInitialized()
        {
            RestaurantsList = _dbContext.Restaurants.ToList();
        }

        private void SelectedRestaurant(ServerAppProgramming.Models.Restaurants item)
        {
            selectedRestaurant = item;
            State = ComponentsState.SelectCategory;
        }

        private void OnBack()
        {
            State = ComponentsState.None;
        }
    }
}
