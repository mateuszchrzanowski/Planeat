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
            new Product("Milk", 3.50M, new Guid()),
            new Product("Flour", 2.75M, new Guid()),
            new Product("Pasta", 5.47M, new Guid()),
            new Product("Sugar", 4.99M, new Guid()),
            new Product("Tea", 13.20M, new Guid()),
            new Product("Coffee", 23.30M, new Guid()),
        };
        
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
        
        public async Task AddAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Product product)
        {
            await Task.CompletedTask;
        }
        public async Task RemoveAsync(Product product)
        {
            _products.Remove(product);
            await Task.CompletedTask;
        }
    }
}
