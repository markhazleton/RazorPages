namespace WiredBrainCoffee.Shared
{
    /// <summary>
    /// Shared constants for the WiredBrainCoffee application suite
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        /// API endpoint configuration
        /// </summary>
        public static class ApiEndpoints
        {
            public const string DefaultApiBaseUrl = "https://localhost:7024";
            public const string MenuEndpoint = "menu";
            public const string ContactEndpoint = "contact";
            public const string OrdersEndpoint = "orders";
            public const string OrderStatusEndpoint = "order-status";
            public const string HealthEndpoint = "health";
            public const string ChatHubEndpoint = "chathub";
        }

        /// <summary>
        /// Port configuration for different services
        /// </summary>
        public static class Ports
        {
            public const int ApiPort = 7024;
            public const int RazorPagesPort = 5000;
            public const int BlazorWasmPort = 5001;
        }

        /// <summary>
        /// Configuration keys
        /// </summary>
        public static class ConfigKeys
        {
            public const string ApiBaseUrl = "ApiSettings:BaseUrl";
            public const string ConnectionStringOrders = "ConnectionStrings:Orders";
            public const string DefaultConnectionString = "Data Source=Orders.db";
        }

        /// <summary>
        /// CORS policy names
        /// </summary>
        public static class CorsPolicies
        {
            public const string DefaultPolicy = "DefaultPolicy";
            public const string DevelopmentPolicy = "DevelopmentPolicy";
        }

        /// <summary>
        /// Application settings
        /// </summary>
        public static class Settings
        {
            public const string ApplicationName = "WiredBrainCoffee";
            public const string ApiVersion = "v1";
        }
    }
}
