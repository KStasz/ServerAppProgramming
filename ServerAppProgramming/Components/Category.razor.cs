using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using ServerAppProgramming.Data;
using ServerAppProgramming.Models;

namespace ServerAppProgramming.Components
{
    public partial class Category : ComponentBase
    {
        [Inject]
        public ApplicationDbContext _dbContext { get; set; }

        #region Parameters
        [Parameter]
        public EventCallback OnClickBack { get; set; }

        public ComponentsState actualState { get; set; }

        [Parameter]
        public ServerAppProgramming.Models.Restaurants restaurant { get; set; }

        #endregion

        #region Properties
        public List<Categories> CategoryList { get; set; }

        public ServerAppProgramming.Models.Categories selectedCategory { get; set; }

        #endregion

        protected override void OnInitialized()
        {
            CategoryList = _dbContext.Categories.ToList();
        }

        private void OnBack()
        {
            actualState = ComponentsState.SelectCategory;
        }

        private void OnSelectedCategory(ServerAppProgramming.Models.Categories item)
        {
            selectedCategory = item;
            actualState = ComponentsState.SelectMeal;
        }

    }
}
