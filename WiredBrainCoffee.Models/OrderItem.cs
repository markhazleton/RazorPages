using System;
using System.Linq;

namespace WiredBrainCoffee.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Extras Extras { get; set; }
    }
}
