using Planeat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Repositories
{
    public interface IRoleRepository : IRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetAsync(string name);
        Task AddAsync(Role role);
    }
}
