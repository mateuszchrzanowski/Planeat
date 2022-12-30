using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Services
{
    public interface IRoleService : IService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto> GetAsync(string name);
        Task CreateAsync(string name);
    }
}
