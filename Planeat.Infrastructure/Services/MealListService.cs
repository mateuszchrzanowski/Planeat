using AutoMapper;
using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Services
{
    public class MealListService : IMealListService
    {
        private readonly IMapper _mapper;
        private readonly IMealListRepository _mealListRespository;

        public MealListService(IMapper mapper, IMealListRepository mealListRespository)
        {
            _mapper = mapper;
            _mealListRespository = mealListRespository;
        }

        public Task CreateAsync(Guid owner, IEnumerable<Meal> meals)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MealListDto>> GetAllAsync()
        {
            IEnumerable<MealList> mealLists = await _mealListRespository.GetAllAsync();
            return _mapper.Map<IEnumerable<MealList>, IEnumerable<MealListDto>>(mealLists);
        }

        public async Task<MealListDto> GetAsync(Guid id)
        {
            MealList mealList = await _mealListRespository.GetAsync(id);
            return _mapper.Map<MealList, MealListDto>(mealList);
        }
    }
}
