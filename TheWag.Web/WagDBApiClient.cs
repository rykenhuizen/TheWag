using System.Net.Http.Json;
using Azure;
using TheWag.Models;

namespace TheWag.Web
{
    public class WagDBApiClient(HttpClient httpClient)
    {
        public async Task<ProductDTO?> GetProductAsync(string id, CancellationToken cancellationToken = default)
        {
            var results = await httpClient.GetFromJsonAsync<ProductDTO>($"/product/{id}", cancellationToken);
            return results;
        }

        public async Task<IList<ProductDTO>> GetAllProductsAsync(CancellationToken cancellationToken = default)
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

        public async void SaveProductAsync(ProductDTO product, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.PostAsJsonAsync("/product", product, cancellationToken);
            response.EnsureSuccessStatusCode();
            //return true;
        }
    }
}
