using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private static ISet<Product> _products = new HashSet<Product>
        {
            new Product("Milk", 3.50M, new Guid("010B4A82-1B7C-11CF-9D53-00AA003C9CB6")),
            new Product("Flour", 2.75M, new Guid("020B4A82-1B7C-11CF-9D53-00AA003C9CB6")),
            new Product("Pasta", 5.47M, new Guid("020B4A82-1B7C-11CF-9D53-00AA003C9CB6")),
            new Product("Sugar", 4.99M, new Guid("030B4A82-1B7C-11CF-9D53-00AA003C9CB6")),
            new Product("Tea", 13.20M, new Guid("040B4A82-1B7C-11CF-9D53-00AA003C9CB6")),
            new Product("Coffee", 23.30M, new Guid("050B4A82-1B7C-11CF-9D53-00AA003C9CB6")),
        };

        public async Task AddAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IEnumerable<Product> products = await Task.FromResult(_products);
            return products;
        }

        public async Task<Product> GetAsync(Guid id)
        {
            Product product = await Task.FromResult(_products.SingleOrDefault(p => p.Id == id));
            return product;
        }

        public async Task<Product> GetAsync(string name)
        {
            Product product = await Task.FromResult(_products.SingleOrDefault(p => p.Name == name));
            return product;
        }

        public async Task RemoveAsync(Guid id)
        {
            Product product = await GetAsync(id);
            _products.Remove(product);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Product product)
        {
            await Task.CompletedTask;
        }
    }
}
