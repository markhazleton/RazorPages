using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffee.Models;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IMenuService _menuService;

        public List<MenuItem> Menu { get; set; } = new();

        public MenuModel(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task OnGetAsync()
        {
            Menu = await _menuService.GetMenuItemsAsync();
        }
    }
}
