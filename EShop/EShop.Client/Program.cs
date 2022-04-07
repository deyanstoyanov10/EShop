using EShop.Client;
using EShop.Client.Services.Authentication;
using EShop.Client.Services.Authentication.Contracts;
using EShop.Client.Services.Category;
using EShop.Client.Services.Category.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazored.LocalStorage;
using EShop.Client.Services.Hub;
using EShop.Client.Services.Hub.Contracts;
using BlazorComponentBus;
using Blazored.SessionStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7030/") });
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IHubService, HubService>();
builder.Services.AddScoped<ComponentBus>();
builder.Services.AddBlazoredSessionStorage();
await builder.Build().RunAsync();
