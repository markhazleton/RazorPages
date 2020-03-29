using System.Collections.Generic;
using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Services
{
    public interface IMenuService
    {
        List<MenuItem> GetMenuItems();
    }
}