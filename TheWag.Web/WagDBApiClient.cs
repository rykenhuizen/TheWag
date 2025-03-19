using TheWag.Models;

namespace TheWag.Web
{
    public class WagDBApiClient(HttpClient httpClient)
    {
        public async Task<IList<Product>> GetProductsAsync(string? name, CancellationToken cancellationToken = default)
        {
            List<Product>? products = null;
            await foreach (var product in httpClient.GetFromJsonAsAsyncEnumerable<Product>("/products", cancellationToken))
            {
                if (product is not null)
                {
                    products ??= [];
                    products.Add(product);
                }
            }
            return products?.ToArray() ?? [];
        }
    }
}
