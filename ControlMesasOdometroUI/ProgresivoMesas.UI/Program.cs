using ProgresivoMesasOdometro.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7217/") });
//builder.Services.AddScoped<ControlMesasService>();
//builder.Services.AddHttpClient<ControlMesasService>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:7217/");
//});
builder.Services.AddHttpClient(); // Configura IHttpClientFactory
builder.Services.AddSingleton<ControlMesasOdometroService>(); // Registro como Singleton
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
