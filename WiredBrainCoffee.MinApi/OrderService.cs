using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffee.MinApi
{
    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _context;

        public OrderService(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task UpdateOrderAsync(int id, Order newOrder)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                order.Description = newOrder.Description;
                order.PromoCode = newOrder.PromoCode;
                order.Total = newOrder.Total;
                order.OrderNumber = newOrder.OrderNumber;
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

    public interface IOrderService
    {
        Task<Order> AddOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
        Task<Order> GetOrderByIdAsync(int id);
        Task<List<Order>> GetOrdersAsync();
        Task UpdateOrderAsync(int id, Order newOrder);
    }
}
