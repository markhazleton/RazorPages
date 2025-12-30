namespace WiredBrainCoffee.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for Order used in MinApi-style endpoints
    /// Represents a flattened order structure for database storage
    /// </summary>
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderNumber { get; set; }
        public string PromoCode { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public decimal Total { get; set; }
    }
}
