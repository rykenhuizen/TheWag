using TheWag.Models;

namespace TheWag.Web
{
    public class WagDBApiClient(HttpClient httpClient)
    {
        public async Task<IList<ProductDTO>> GetProductsAsync(string? name, CancellationToken cancellationToken = default)
        {
            List<ProductDTO>? products = null;
            await foreach (var product in httpClient.GetFromJsonAsAsyncEnumerable<ProductDTO>("/product", cancellationToken))
            {
                if (product is not null)
                {
                    products ??= [];
                    products.Add(product);
                }
            }
            return products?.ToArray() ?? [];
        }

        public async Task<IList<WeatherForecast>> GetWeatherAsync(CancellationToken cancellationToken = default)
        {
            List<WeatherForecast>? weather = null;
            await foreach (var WeatherForecast in httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>("/weatherforecast", cancellationToken))
            {
                if (WeatherForecast is not null)
                {
                    weather ??= [];
                    weather.Add(WeatherForecast);
                }
            }
            return weather?.ToArray() ?? [];
        }

        public class WeatherForecast
        {
            public DateOnly Date { get; set; }

            public int TemperatureC { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

            public string? Summary { get; set; }
        }
    }
}
