using Planeat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Repositories
{
    public interface IMealListRepository : IRepository
    {
        Task<IEnumerable<MealList>> GetAllAsync();
        Task<MealList> GetAsync(Guid id);
        Task CreateAsync(Guid owner, IEnumerable<Meal> meals);
    }
}
