using EFDemo1.Data;
using System.Collections.Generic;
using System.Linq;

namespace EFDemo1.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public IEnumerable<Product> RemoveProduct(int id)
        {
            var product = context.Products.Single(x => x.Id == id);
            context.Products.Remove(product);
            context.SaveChanges();
            return context.Products;
        }

        public IEnumerable<Product> UpsertProduct(Product product)
        {
            // Add
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            // Update
            else
            {
                var stored = context.Products.Single(x => x.Id == product.Id);
                stored.Name = product.Name;
                stored.Price = product.Price;
            }

            context.SaveChanges();

            return context.Products;
        }
    }
}
