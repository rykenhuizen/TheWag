using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWag.Models;

namespace TheWag.Data
{
    public class CartRepo
    {
        public Cart GetCart()
        {
            var cus = new Customer { Email ="Bradrykenhuizen@gmail.com"};
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
                    Id=4,
                    URL = "images/dogs/dog4.png",
                    Price = 400.00m,
                    Stock = 20,
                    Description = "Dog party"
                }
            };

            var items = new List<CartItem>
            {
                new CartItem
                {
                    Product = products[0],
                    Quantity = 4
                },
                new CartItem
                {
                    Product = products[1],
                    Quantity = 1
                }
            };



            var cart = new Cart { Customer = cus, Items = items, Promo = null };

            return cart;
        }
    }
}
