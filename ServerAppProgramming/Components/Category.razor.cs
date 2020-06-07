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

        public List<Categories> CategoryList { get; set; }

        protected override void OnInitialized()
        {
            CategoryList = _dbContext.Categories.ToList();
        }

    }
}
