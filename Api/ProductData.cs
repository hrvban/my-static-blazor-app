using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public interface IProductData
    {
        Task<Product> AddProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> UpdateProduct(Product product);
    }

    public class ProductData : IProductData
    {
        private readonly List<Product> products = new List<Product>
        {
            new Product
            {
                Id = 10,
                Name = "Erdbeeren",
                Description = "250gr Packung Bio-Erdbeeren",
                Quantity = 1
            },
            new Product
            {
                Id = 20,
                Name = "Brot",
                Description = "Mit Vollkorn- und Dinkelmehl",
                Quantity = 1
            },
            new Product
            {
                Id = 30,
                Name = "Äpfel",
                Description = "ein Sack Fuji-Äpfel aus der Steiermark",
                Quantity = 1
            }
        };

        private int GetRandomInt()
        {
            var random = new Random();
            return random.Next(100, 1000);
        }

        public Task<Product> AddProduct(Product product)
        {
            product.Id = GetRandomInt();
            products.Add(product);
            return Task.FromResult(product);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            var index = products.FindIndex(p => p.Id == product.Id);
            products[index] = product;
            return Task.FromResult(product);
        }

        public Task<bool> DeleteProduct(int id)
        {
            var index = products.FindIndex(p => p.Id == id);
            products.RemoveAt(index);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            return Task.FromResult(products.AsEnumerable());
        }
    }
}
