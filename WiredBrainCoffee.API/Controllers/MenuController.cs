using Microsoft.AspNetCore.Mvc;
using WiredBrainCoffee.Api.Services;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuService _menuService;

        public MenuController(ILogger<MenuController> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MenuItem>> Get()
        {
            _logger.LogInformation("Fetching all menu items");
            return Ok(_menuService.GetMenuItems());
        }

        [HttpGet("{id:int}")]
        public ActionResult<MenuItem> GetById(int id)
        {
            _logger.LogInformation("Fetching menu item with ID: {Id}", id);
            var menuItem = _menuService.GetMenuItemById(id);
            
            if (menuItem == null)
            {
                _logger.LogWarning("Menu item with ID: {Id} not found", id);
                return NotFound();
            }

            return Ok(menuItem);
        }

        [HttpGet("slug/{slug}")]
        public ActionResult<MenuItem> GetBySlug(string slug)
        {
            _logger.LogInformation("Fetching menu item with slug: {Slug}", slug);
            var menuItem = _menuService.GetMenuItemBySlug(slug);
            
            if (menuItem == null)
            {
                _logger.LogWarning("Menu item with slug: {Slug} not found", slug);
                return NotFound();
            }

            return Ok(menuItem);
        }

        [HttpGet("category/{category}")]
        public ActionResult<IEnumerable<MenuItem>> GetByCategory(string category)
        {
            _logger.LogInformation("Fetching menu items for category: {Category}", category);
            var menuItems = _menuService.GetMenuItemsByCategory(category);
            return Ok(menuItems);
        }
    }
}
