using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Repositories
{
    public class InMemoryProductListRepository : IProductListRepository
    {
        private static ISet<ProductList> _productLists = new HashSet<ProductList>();

        public async Task AddAsync(ProductList productList)
        {
            _productLists.Add(productList);
            await Task.CompletedTask;
        }

        public Task<IEnumerable<ProductList>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductList> GetAsync(Guid id)
        {
            ProductList productList = await Task.FromResult(_productLists.SingleOrDefault(x => x.Id == id));
            return productList;
        }

        public async Task RemoveAsync(Guid id)
        {
            ProductList productList = await GetAsync(id);
            _productLists.Remove(productList);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(ProductList productList)
        {
            await RemoveAsync(productList.Id);
            //_users.Remove(oldUser);

            _productLists.Add(productList);
            await Task.CompletedTask;
        }
    }
}
