using EFDemo1.Data;
using System.Collections.Generic;

namespace EFDemo1.Services
{
    public class ProductService
    {
        private readonly BaseRepository<Product> repository;

        public ProductService(BaseRepository<Product> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return repository.GetAllItems();
        }

        public IEnumerable<Product> GetProductsMoreExpensiveThan(decimal price)
        {
            return repository.GetByCriteria(x => x.Price > price);
        }

        public IEnumerable<Product> RemoveProduct(int id)
        {
            var product = repository.GetByKey(id);
            repository.Remove(product);
            return repository.GetAllItems();
        }

        public IEnumerable<Product> UpsertProduct(Product product)
        {
            // Add
            if (product.Id == 0)
            {
                repository.Insert(product);
            }
            // Update
            else
            {
                repository.Update(product);
            }
            return repository.GetAllItems();
        }
    }
}
