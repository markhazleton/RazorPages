using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.MinApi;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Orders") ?? "Data Source=Orders.db";

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddSqlite<OrderDbContext>(connectionString);
builder.Services.AddHealthChecks();
builder.Services.AddHttpClient();
builder.Services.AddResponseCompression();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Default", policy =>
        policy.WithOrigins("https://trustedclient.com") // Replace with trusted client URLs
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Ensure database is ready
await CreateDb(app.Services, app.Logger);

// Configure the middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Default");
app.UseResponseCompression();
app.MapHealthChecks("/health");

// Define endpoints
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
.WithName("Get system status");

app.MapGet("/orders/{id}", async (int id, IOrderService orderService, ILogger<Program> logger) =>
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
.WithName("Get order by id");

app.MapGet("/orders", async (IOrderService orderService, ILogger<Program> logger) =>
{
    logger.LogInformation("Fetching all orders...");
    var orders = await orderService.GetOrdersAsync();
    return Results.Ok(orders);
})
.WithName("Get orders");

app.MapPost("/orders", async (Order newOrder, IOrderService orderService, ILogger<Program> logger) =>
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
.WithName("Create order");

app.MapPut("/orders/{id}", async (int id, Order updatedOrder, IOrderService orderService, ILogger<Program> logger) =>
{
    logger.LogInformation("Updating order with ID: {Id}", id);
    await orderService.UpdateOrderAsync(id, updatedOrder);
    return Results.NoContent();
})
.WithName("Update order");

app.MapDelete("/orders/{id}", async (int id, IOrderService orderService, ILogger<Program> logger) =>
{
    logger.LogInformation("Deleting order with ID: {Id}", id);
    await orderService.DeleteOrderAsync(id);
    return Results.Ok();
})
.WithName("Delete order");

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
