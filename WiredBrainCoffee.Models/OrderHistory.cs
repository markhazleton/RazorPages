using System;

namespace WiredBrainCoffee.Models
{
    public class OrderHistory
    {
        public List<Order> Orders { get; set; }
        public int TotalOrderCount { get; set; }

        public OrderHistory()
        {
            Orders = new List<Order>();
        }
    }
}
