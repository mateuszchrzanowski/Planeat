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
            await RemoveAsync(user.Id);
            //_users.Remove(oldUser);

            _users.Add(user);
            await Task.CompletedTask;
        }
    }
}
