using Blazored.Modal;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WiredBrainCoffee.UI;
using WiredBrainCoffee.UI.Components;
using WiredBrainCoffee.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Note: RegisterForJavaScript is commented out because the JavaScript code
// that uses it is also commented out due to API changes in .NET 9
// builder.RootComponents.RegisterForJavaScript<GlobalAlert>(identifier: "globalAlert");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredModal();
builder.Services.AddBlazorise(options =>
{
})
  .AddBootstrapProviders()
  .AddFontAwesomeIcons();

// Configure all services to use the consolidated API
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7024/";

builder.Services.AddHttpClient<IMenuService, MenuService>(client =>
    client.BaseAddress = new Uri(apiBaseUrl));
builder.Services.AddHttpClient<IContactService, ContactService>(client =>
    client.BaseAddress = new Uri(apiBaseUrl));
builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
    client.BaseAddress = new Uri(apiBaseUrl));

var host = builder.Build();

await host.RunAsync();
