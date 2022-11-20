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
        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@user.com", "user1", "secret1", "salt1"),
            new User("user2@user.com", "user2", "secret2", "salt2"),
            new User("user3@user.com", "user3", "secret3", "salt3")
        };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            IEnumerable<User> users = await Task.FromResult(_users);
            return users;
        }

        public async Task<User> GetAsync(Guid id)
        {
            User user = await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));
            return user;
        }

        public async Task<User> GetAsync(string email)
        {
            User user = await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLowerInvariant()));
            return user;
        }

        public async Task RemoveAsync(Guid id)
        {
            User user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
