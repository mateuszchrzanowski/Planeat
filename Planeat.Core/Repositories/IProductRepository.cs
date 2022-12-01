using Planeat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Repositories
{
    public interface IProductRepository : IRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(Guid id);
        Task<Product> GetAsync(string name);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task RemoveAsync(Product product);
    }
}
