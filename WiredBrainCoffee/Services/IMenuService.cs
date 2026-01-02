using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Services
{
    public interface IMenuService
    {
        Task<List<MenuItem>> GetMenuItemsAsync();
    }
}