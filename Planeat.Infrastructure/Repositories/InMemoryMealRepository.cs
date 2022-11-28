using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Repositories
{
    public class InMemoryMealRepository : IMealRepository
    {
        private static ISet<Meal> _meals = new HashSet<Meal>
        {
            new Meal("Pizza", null, new Guid()),
            new Meal("Tomato Soup", null, new Guid()),
            new Meal("Carbonara", null, new Guid())
        };

        public async Task<IEnumerable<Meal>> GetAllAsync()
        {
            IEnumerable<Meal> meals = await Task.FromResult(_meals);
            return meals;
        }

        public async Task AddAsync(Meal meal)
        {
            _meals.Add(meal);
            await Task.CompletedTask;
        }

        public async Task<Meal> GetAsync(Guid id)
        {
            Meal meal = await Task.FromResult(_meals.SingleOrDefault(
                m => m.Id == id));
            return meal;
        }

        public async Task<Meal> GetAsync(string name)
        {
            Meal meal = await Task.FromResult(_meals.SingleOrDefault(
                m => m.Name.ToLower() == name.ToLower()));
            return meal;
        }

        public Task<IEnumerable<Meal>> GetByCreatedByAsync(Guid createdBy)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Meal meal)
        {
            _meals.Remove(meal);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Meal meal)
        {
            await Task.CompletedTask;
        }
    }
}
