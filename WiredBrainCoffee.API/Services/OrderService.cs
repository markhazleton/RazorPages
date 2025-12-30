using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.Api.Data;
using WiredBrainCoffee.Models.DTOs;

namespace WiredBrainCoffee.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;

        public OrderService(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OrderDto> AddOrderAsync(OrderDto order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task UpdateOrderAsync(int id, OrderDto newOrder)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                order.Description = newOrder.Description;
                order.PromoCode = newOrder.PromoCode;
                order.Total = newOrder.Total;
                order.OrderNumber = newOrder.OrderNumber;
                order.CustomerName = newOrder.CustomerName;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
