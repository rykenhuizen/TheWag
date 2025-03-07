using Microsoft.Extensions.DependencyInjection;
using TheWag.Util.Azure;
using TheWag.Web;
using TheWag.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddSingleton<BlobService>(new BlobService("thewagstorage"));
//builder.Services.AddSingleton<ComputerVisionService>(new ComputerVisionService("thewagcomputervision"));

//lazy load
builder.Services.AddSingleton<BlobService>(serviceProvider => new BlobService("thewagstorage"));
builder.Services.AddSingleton<ComputerVisionService>(serviceProvider => new ComputerVisionService("thewagcomputervision"));

builder.Services.AddHttpClient<WeatherApiClient>(client =>
    {
        // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
        // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
        client.BaseAddress = new("https+http://apiservice");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseOutputCache();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
