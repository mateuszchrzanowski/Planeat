using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Services
{
    public interface IMealService : IService
    {
        //Task<IEnumerable<MealDto>> GetByCreatedByAsync(Guid createdBy);
        Task<IEnumerable<MealDto>> GetAllAsync();
        Task<MealDto> GetAsync(string name);
        Task<MealDto> GetAsync(Guid id);
        Task CreateAsync(string name, IEnumerable<IngredientDto> ingredients, Guid createdBy);
        Task UpdateAsync(Guid id, string name, IEnumerable<IngredientDto> ingredients);
        Task DeleteAsync(Guid id);
    }
}
