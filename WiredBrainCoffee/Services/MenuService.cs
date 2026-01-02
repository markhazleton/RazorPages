using System.Net.Http.Json;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Services
{
    public class MenuService : IMenuService
    {
        private readonly HttpClient _httpClient;

        public MenuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MenuItem>> GetMenuItemsAsync()
        {
            try
            {
                var menuItems = await _httpClient.GetFromJsonAsync<List<MenuItem>>("menu");
                return menuItems ?? new List<MenuItem>();
            }
            catch (HttpRequestException ex)
            {
                // Log error and return empty list (could also throw or return cached data)
                Console.WriteLine($"Error fetching menu items from API: {ex.Message}");
                return new List<MenuItem>();
            }
        }
    }
}