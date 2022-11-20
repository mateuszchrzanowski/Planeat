using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Services
{
    public interface IProductService : IService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetAsync(string name);
        Task CreateAsync(string name, decimal price, Guid cretaedBy);
    }
}
