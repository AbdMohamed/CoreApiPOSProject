using Microsoft.AspNet.SignalR;
using OURCart.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurCart.Hubs
{
    public class CategoryHub:Hub
    {
        private ICategoryService _CategoryService;
        public CategoryHub(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        public void GetCategory(string name, string message)
        {
            // Call the "GetCategory" method to update clients.
       //    var categories=_CategoryService.GetCategories();
            Clients.All.SendCoreAsync("GetCategory", new object[] { name, message });
        }

    }
}
