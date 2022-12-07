using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Repositories
{
    public class InMemoryRoleRepository : IRoleRepository
    {
        private static ISet<Role> _roles = new HashSet<Role>
        {
            new Role(1, "user"),
            new Role(2, "admin"),
        };

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            IEnumerable<Role> roles = await Task.FromResult(_roles);
            return roles;
        }

        public async Task<Role> GetAsync(int id)
        {
            Role role = await Task.FromResult(_roles.SingleOrDefault(r => r.Id == id));
            return role;
        }
    }
}
