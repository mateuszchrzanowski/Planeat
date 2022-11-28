using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.Meals;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Handlers.Meals
{
    public class CreateMealHandler : ICommandHandler<CreateMeal>
    {
        private readonly IMealService _mealService;

        public CreateMealHandler(IMealService mealService)
        {
            _mealService = mealService;
        }

        public async Task HandleAsync(CreateMeal command)
        {
            await _mealService.CreateAsync(command.Name, command.Ingredients, command.CreatedBy);
        }
    }
}
