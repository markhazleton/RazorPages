using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.Api.Data;
using WiredBrainCoffee.Api.Hubs;
using WiredBrainCoffee.Api.Models;
using WiredBrainCoffee.Api.Services;
using WiredBrainCoffee.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Orders") ?? "Data Source=Orders.db";

// Add services to the container
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Business services
builder.Services.AddSingleton<IMenuService, MenuService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Database and infrastructure
builder.Services.AddSqlite<OrderDbContext>(connectionString);
builder.Services.AddHealthChecks();
builder.Services.AddHttpClient();
builder.Services.AddResponseCompression();

builder.Services.AddHttpLogging(httpLogging =>
{
    httpLogging.LoggingFields = HttpLoggingFields.All;
});

var app = builder.Build();

// Ensure database is ready
await CreateDb(app.Services, app.Logger);

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    context.Request.Headers.AcceptLanguage = "C# Forever";
    context.Response.Headers.XPoweredBy = "ASPNETCORE 6.0";
    await next.Invoke(context);
});

app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseResponseCompression();
app.UseAuthorization();

// Map Controllers and SignalR Hub
app.MapControllers();
app.MapHub<ChatHub>("/chathub");
app.MapHealthChecks("/health");

// Map Minimal API endpoints for orders
app.MapGet("/order-status", async (IHttpClientFactory factory, ILogger<Program> logger) =>
{
    var client = factory.CreateClient();
    try
    {
        logger.LogInformation("Fetching order system status...");
        var response = await client.GetFromJsonAsync<OrderSystemStatus>("https://wiredbraincoffee.azurewebsites.net/api/OrderSystemStatus");

        if (response == null)
        {
            logger.LogWarning("Order system status response was null.");
            return Results.Problem("Unable to fetch order system status.", statusCode: 503);
        }

        return Results.Ok(response);
    }
    catch (HttpRequestException ex)
    {
        logger.LogError(ex, "Error fetching order system status.");
        return Results.Problem("Unable to fetch order system status.", statusCode: 503);
    }
})
.WithName("GetSystemStatus")
.WithTags("Orders");

app.MapGet("/orders/{id:int}", async (int id, IOrderService orderService, ILogger<Program> logger) =>
{
    logger.LogInformation("Fetching order with ID: {Id}", id);
    var order = await orderService.GetOrderByIdAsync(id);

    if (order == null)
    {
        logger.LogWarning("Order with ID: {Id} not found.", id);
        return Results.NotFound();
    }

    return Results.Ok(order);
})
.WithName("GetOrderById")
.WithTags("Orders");

app.MapGet("/orders", async (IOrderService orderService, ILogger<Program> logger) =>
{
    logger.LogInformation("Fetching all orders...");
    var orders = await orderService.GetOrdersAsync();
    return Results.Ok(orders);
})
.WithName("GetOrders")
.WithTags("Orders");

app.MapPost("/orders", async (OrderDto newOrder, IOrderService orderService, ILogger<Program> logger) =>
{
    if (string.IsNullOrWhiteSpace(newOrder.CustomerName))
    {
        logger.LogWarning("Invalid order creation attempt with missing customer name.");
        return Results.BadRequest("Customer name is required.");
    }

    logger.LogInformation("Creating new order for customer: {CustomerName}", newOrder.CustomerName);
    var createdOrder = await orderService.AddOrderAsync(newOrder);
    return Results.Created($"/orders/{createdOrder.Id}", createdOrder);
})
.WithName("CreateOrder")
.WithTags("Orders");

app.MapPut("/orders/{id:int}", async (int id, OrderDto updatedOrder, IOrderService orderService, ILogger<Program> logger) =>
{
    logger.LogInformation("Updating order with ID: {Id}", id);
    await orderService.UpdateOrderAsync(id, updatedOrder);
    return Results.NoContent();
})
.WithName("UpdateOrder")
.WithTags("Orders");

app.MapDelete("/orders/{id:int}", async (int id, IOrderService orderService, ILogger<Program> logger) =>
{
    logger.LogInformation("Deleting order with ID: {Id}", id);
    await orderService.DeleteOrderAsync(id);
    return Results.Ok();
})
.WithName("DeleteOrder")
.WithTags("Orders");

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();

async Task CreateDb(IServiceProvider services, ILogger logger)
{
    try
    {
        using var scope = services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
        await dbContext.Database.MigrateAsync();
        logger.LogInformation("Database migration completed successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating the database.");
        throw;
    }
}
