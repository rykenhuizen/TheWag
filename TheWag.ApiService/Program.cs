using TheWag.Api.WagDB;
using TheWag.Models;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddSqlServerDbContext<TheWagDBContext>(connectionName: "wagdb");

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/products", () =>
{
    var products = new List<Product>
            {
                new Product
                {
                    Id=1,
                    URL = "images/dogs/dog1.png",
                    Price = 100.00m,
                    Stock = 0,
                    Description = "Majestic!"
                },
                new Product
                {
                    Id=2,
                    URL = "images/dogs/dog2.png",
                    Price = 200.00m,
                    Stock = 1,
                    Description = "What a cuttie"
                },
                new Product
                {
                    Id=3,
                    URL = "images/dogs/dog3.png",
                    Price = 300.00m,
                    Stock = 10,
                    Description = "Hi there"
                },
                new Product
                {
                    Id=4,
                    URL = "images/dogs/dog4.png",
                    Price = 400.00m,
                    Stock = 20,
                    Description = "Dog party"
                },
                new Product
                {
                    Id=5,
                    URL = "images/dogs/dog5.png",
                    Price = 500.00m,
                    Stock = 4,
                    Description = "Dog park"
                }
            };

    return products;
})
.WithName("GetProducts");

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
