using Planeat.Core.Domain;
using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Services
{
    public interface IMealListService : IService
    {
        Task<IEnumerable<MealListDto>> GetAllAsync();
        Task<MealListDto> GetAsync(Guid id);
        Task CreateAsync(Guid owner, IEnumerable<Meal> meals);
    }
}
