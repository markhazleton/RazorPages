using WiredBrainCoffee.Models.DTOs;

namespace WiredBrainCoffee.Api.Services
{
    public interface IOrderService
    {
        Task<OrderDto> AddOrderAsync(OrderDto order);
        Task DeleteOrderAsync(int id);
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task<List<OrderDto>> GetOrdersAsync();
        Task UpdateOrderAsync(int id, OrderDto newOrder);
    }
}
