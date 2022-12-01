using Planeat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Repositories
{
    public interface IMealRepository : IRepository
    {
        Task<IEnumerable<Meal>> GetAllAsync();
        Task<Meal> GetAsync(string name);
        Task<Meal> GetAsync(Guid id);
        Task AddAsync(Meal meal);
        Task UpdateAsync(Meal meal);
        Task RemoveAsync(Meal meal);
        //Task<IEnumerable<Meal>> GetByCreatedByAsync(Guid createdBy);
    }
}
