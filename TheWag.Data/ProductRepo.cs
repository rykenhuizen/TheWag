using TheWag.Models;

namespace TheWag.Data
{
    public class ProductRepo
    {
        public ProductRepo() { }

        public IList<Product> GetProducts(string ?name) 
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
        }
    }
}
