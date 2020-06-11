using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerAppProgramming.Data;
using System.Security.Claims;
using ServerAppProgramming.Models;
using System.Threading.Tasks;

namespace ServerAppProgramming.Components
{
    public partial class Order : ComponentBase
    {
        [Inject]
        public AuthenticationStateProvider authenticationStateProvider { get; set; }

        [Inject]
        public ApplicationDbContext _dbContext { get; set; }

        #region Properties
        public List<SummaryOrder> listOrder { get; set; }

        public List<ServerAppProgramming.Models.Order> dbOrder { get; set; }

        public int Quantity { get; set; }

        public bool Error { get; set; } = false;

        public string ErrorMessage { get; set; } = String.Empty;

        #endregion

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            listOrder = await ReadData();
        }

        private async Task<List<Models.SummaryOrder>> ReadData()
        {
            var auth = await authenticationStateProvider.GetAuthenticationStateAsync();
            string user = auth.User.Identity.Name;
            List<SummaryOrder> locallist = new List<SummaryOrder>();
            dbOrder = _dbContext.Order.Where(x => x.UserId == _dbContext.Users.Where(y => y.Email == user).First().Id).ToList();
            foreach (var item in dbOrder)
            {
                locallist.Add(new SummaryOrder
                {
                    Id = item.Id,
                    meal = _dbContext.Meals.Where(x => x.Id == item.MealId).First(),
                    restaurant = _dbContext.Restaurants.Where(x => x.Id == item.RestaurantId).First(),
                    Quantity = item.Quantity > 0 ? item.Quantity : 0,
                    date = item.CreationDate,
                    IsInWeryfication = item.IsInWeryfication,
                    IsInEdit = item.Quantity > 0 ? false : true
                });
            }
            return locallist;
        }

        private async Task SaveQuantity(SummaryOrder item)
        {
            ServerAppProgramming.Models.Order selectedOrder = _dbContext.Order.Where(x => x.Id == item.Id).First();
            selectedOrder.Quantity = item.Quantity;
            _dbContext.Order.Update(selectedOrder);
            await _dbContext.SaveChangesAsync();
            listOrder = await ReadData();
        }

        private void UpdateQuantity(SummaryOrder item)
        {
            listOrder.Remove(item);
            item.Quantity = 0;
            item.IsInEdit = true;
            listOrder.Add(item);
            listOrder = listOrder.OrderBy(x => x.Id).ToList();
        }

        private async Task DeleteOrder(SummaryOrder item)
        {
            _dbContext.Order.Remove(_dbContext.Order.Where(x => x.Id == item.Id).First());
            await _dbContext.SaveChangesAsync();
            listOrder = await ReadData();
        }

        private async Task SaveOrder()
        {
            if (dbOrder.Any(x => x.Quantity <= 0))
            {
                Error = true;
                ErrorMessage = "Nie wszystkie pozycje zamówienia mają ilosć większą od 0";
            }
            else
            {
                dbOrder = dbOrder.Where(x => x.Quantity > 0 && x.IsInWeryfication == false).ToList();
                foreach (var item in dbOrder)
                {
                    item.IsInWeryfication = true;
                }
                _dbContext.UpdateRange(dbOrder);
                await _dbContext.SaveChangesAsync();
                listOrder = await ReadData();
            }
        }

        private void RemoveError()
        {
            Error = false;
        }
    }
}
