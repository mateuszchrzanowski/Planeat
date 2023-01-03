using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planeat.Core.Domain;

namespace Planeat.Core.Repositories
{
    public interface IProductListRepository : IRepository
    {
        Task<IEnumerable<ProductList>> GetAllAsync();
        Task<ProductList> GetAsync(Guid id);
        Task AddAsync(ProductList productList);
        Task UpdateAsync(ProductList productList);
        Task RemoveAsync(Guid id);
    }
}
