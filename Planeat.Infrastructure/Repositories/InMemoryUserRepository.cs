using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
        {
            User user = _users.Single(x => x.Id == id);
            return user;
        }

        public User Get(string email)
        {
            User user = _users.Single(x => x.Email == email.ToLowerInvariant());
            return user;
        }

        public void Remove(Guid id)
        {
            User user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
