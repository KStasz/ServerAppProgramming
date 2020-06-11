using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using ServerAppProgramming.Data;

namespace ServerAppProgramming.Components
{
    public partial class Meals : ComponentBase
    {
        [Inject]
        public ApplicationDbContext _dbContext { get; set; }

        #region Parameters
        public ComponentsState actualState { get; set; }

        [Parameter]
        public ServerAppProgramming.Models.Categories category { get; set; }

        [Parameter]
        public ServerAppProgramming.Models.Restaurants restaurant { get; set; }

        [Parameter]
        public EventCallback OnClickBack { get; set; }
        #endregion

        #region Properties
        public List<ServerAppProgramming.Models.Meals> mealsList { get; set; }

        #endregion

        protected override void OnInitialized()
        {
            mealsList = _dbContext.Meals.Where(x => x.RestaurantId == restaurant.Id && x.CategoryId == category.Id).ToList();
        }

    }
}
