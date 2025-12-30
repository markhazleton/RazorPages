namespace WiredBrainCoffee.Api.Models
{
    public class OrderSystemStatus
    {
        public string Status { get; set; } = string.Empty;
        public DateTime ScheduledUpdate { get; set; }
        public DateTime UpTime { get; set; }
        public string Version { get; set; } = string.Empty;
    }
}
