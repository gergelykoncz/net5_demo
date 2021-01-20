using System.Collections.Generic;
using System.Linq;

namespace ControllerDemo.Service
{
    public class ProductService
    {
        private List<Product> products = new List<Product>()
        {
            new Product{ Id = 1, Name = "Baseball bat", Price= 30.0},
            new Product{ Id = 2, Name = "Yoga mat", Price= 15.0},
            new Product{ Id = 3, Name = "10kg dumbbells", Price= 45.0},
            new Product{ Id = 4, Name = "Running shoes", Price= 30.0},
            new Product{ Id = 5, Name = "Protein bar", Price= 2.0},
        };

        public IEnumerable<Product> GetProducts()
        {
            return products.AsReadOnly();
        }

        public IEnumerable<Product> RemoveProduct(int id)
        {
            var product = products.Single(x => x.Id == id);
            products.Remove(product);
            return products;
        }

        public IEnumerable<Product> UpsertProduct(Product product)
        {
            // Add
            if (product.Id == 0)
            {
                int maxId = products.Max(x => x.Id);
                product.Id = ++maxId;
                products.Add(product);
            }
            // Update
            else
            {
                var stored = products.Single(x => x.Id == product.Id);
                stored.Name = product.Name;
                stored.Price = product.Price;
            }

            return products;
        }
    }
}
