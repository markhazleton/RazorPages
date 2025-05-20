using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffee.MinApi
{

    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var fixedDate = new DateTime(2024, 1, 1, 8, 0, 0, DateTimeKind.Utc);
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Description = "A coffee order",
                    PromoCode = "Wired123",
                    Created = fixedDate,
                    OrderNumber = 100,
                    Total = 25,
                    CustomerName = "John Doe"
                },
                new Order
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
