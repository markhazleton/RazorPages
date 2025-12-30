using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Api.Services
{
    public interface IMenuService
    {
        List<MenuItem> GetMenuItems();
        MenuItem? GetMenuItemById(int id);
        MenuItem? GetMenuItemBySlug(string slug);
        List<MenuItem> GetMenuItemsByCategory(string category);
    }
}
