using Planeat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Repositories
{
    public interface IMealRepository
    {
        Task<Meal> GetAsync(Guid id);
        Task<Meal> GetAsync(string name);
        Task AddAsync(Meal meal);
        Task UpdateAsync(Meal meal);
        Task RemoveAsync(Guid id);
    }
}
