using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using WiredBrainCoffee.Models;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee.Pages
{
    public class MenuModel : PageModel
    {
        public List<MenuItem> Menu { get; set; }

        public void OnGet()
        {
            var menuService = new MenuService();
            Menu = menuService.GetMenuItems();
        }
    }
}
