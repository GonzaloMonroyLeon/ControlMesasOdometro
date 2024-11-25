using JackpotApp;
//using JackpotApp.Services;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.services.addscoped<jackpotservice>();
// Configura la URL base para HttpClient apuntando a la API de Jackpot
builder.Services.AddScoped(sp => new HttpClient
{
	BaseAddress = new Uri("https://localhost:7217/api/jackpot") // Cambia la URL al endpoint de tu API real
});
await builder.Build().RunAsync();
