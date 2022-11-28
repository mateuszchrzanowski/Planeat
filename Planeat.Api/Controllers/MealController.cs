using Microsoft.AspNetCore.Mvc;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Meals;
using Planeat.Infrastructure.DTO;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Api.Controllers
{
    public class MealController : ApiControllerBase
    {
        private readonly IMealService _mealService;

        public MealController(ICommandDispatcher commandDispatcher,
            IMealService mealService) : base(commandDispatcher)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<MealDto> meals = await _mealService.GetAllAsync();

            return Ok(meals);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            MealDto meal = await _mealService.GetAsync(name);

            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMeal command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"meal/{command.Name}", null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateMeal command)
        {
            await _mealService.UpdateAsync(id, command.Name, command.Ingredients);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mealService.DeleteAsync(id);

            return NoContent();
        }
    }
}
