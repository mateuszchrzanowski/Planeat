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
            new Product("Milk", 3.50M, new Guid("95b57406-673d-4bce-98ac-86a16af49ef5")),
            new Product("Flour", 2.75M, new Guid("b45898c0-5bf6-43a8-9898-c18fd28d491b")),
            new Product("Pasta", 5.47M, new Guid("b45898c0-5bf6-43a8-9898-c18fd28d491b")),
            new Product("Sugar", 4.99M, new Guid("ea357467-90e4-48fa-a93b-b078fe8d6a55")),
            new Product("Tea", 13.20M, new Guid("a0e67d72-3a7d-46da-97ef-917ed0c8a0c3")),
            new Product("Coffee", 23.30M, new Guid("8dedb784-e87f-40fe-a48d-3e84081597fe")),
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
