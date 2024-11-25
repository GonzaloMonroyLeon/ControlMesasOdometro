using ControlMesasOdometroApi.Data;
using JackpotApi.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ControlmesasOdometroRepository.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ControlMesasOdometroContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IControlMesasOdometroRepository, ControlMesasRepository>();

builder.Services.AddScoped<ControlMesasOdometroService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
    {
        policy.WithOrigins("https://localhost:7236/")
              .AllowAnyHeader()
              .AllowAnyOrigin()
              .AllowAnyMethod();
    });
});


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jackpot API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors("AllowBlazorApp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();