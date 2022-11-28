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
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public MealService(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MealDto>> GetAllAsync()
        {
            IEnumerable<Meal> meals = await _mealRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Meal>, IEnumerable<MealDto>>(meals);
        }

        public async Task<MealDto> GetAsync(string name)
        {
            Meal meal = await _mealRepository.GetAsync(name);
            return _mapper.Map<Meal, MealDto>(meal);
        }

        public Task<IEnumerable<MealDto>> GetByCreatedByAsync(Guid createdBy)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(string name, IEnumerable<IngredientDto> ingredients, Guid createdBy)
        {
            Meal meal = await _mealRepository.GetAsync(name);

            if (meal != null)
            {
                throw new Exception($"Meal with name: {name} already exist.");
            }

            var mappedIngredients = _mapper.Map<IEnumerable<IngredientDto>, IEnumerable<Ingredient>>(ingredients);
            meal = new Meal(name, mappedIngredients, createdBy);
            await _mealRepository.AddAsync(meal);
        }

        public async Task<MealDto> GetAsync(Guid id)
        {
            Meal meal = await _mealRepository.GetAsync(id);
            return _mapper.Map<Meal, MealDto>(meal);
        }

        public async Task UpdateAsync(Guid id, string name, IEnumerable<IngredientDto> ingredients)
        {
            Meal meal = await _mealRepository.GetAsync(name);

            if (meal != null)
            {
                throw new Exception($"Meal with name {name} already exist.");
            }

            meal = await _mealRepository.GetAsync(id);

            if (meal == null)
            {
                throw new Exception("Meal does not exist.");
            }

            meal.SetName(name);
            var mappedIngredients = _mapper.Map<IEnumerable<IngredientDto>, IEnumerable<Ingredient>>(ingredients);
            meal.SetIngredients(mappedIngredients);

            await _mealRepository.UpdateAsync(meal);
        }

        public async Task DeleteAsync(Guid id)
        {
            Meal meal = await _mealRepository.GetAsync(id);

            if (meal == null)
            {
                throw new Exception("Meal does not exist.");
            }

            await _mealRepository.RemoveAsync(meal);
        }
    }
}
