using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.Models.DTOs;

namespace WiredBrainCoffee.Api.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<OrderDto> Orders => Set<OrderDto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var fixedDate = new DateTime(2024, 1, 1, 8, 0, 0, DateTimeKind.Utc);
            modelBuilder.Entity<OrderDto>().HasData(
                new OrderDto
                {
                    Id = 1,
                    Description = "A coffee order",
                    PromoCode = "Wired123",
                    Created = fixedDate,
                    OrderNumber = 100,
                    Total = 25,
                    CustomerName = "John Doe"
                },
                new OrderDto
                {
                    Id = 2,
                    Description = "A food order",
                    PromoCode = "Wired123",
                    Created = fixedDate,
                    OrderNumber = 125,
                    Total = 35,
                    CustomerName = "Jane Smith"
                }
            );
        }
    }
}
