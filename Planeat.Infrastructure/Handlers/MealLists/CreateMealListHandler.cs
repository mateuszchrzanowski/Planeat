using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.Commands.MealLists;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Handlers.MealLists
{
    public class CreateMealListHandler : ICommandHandler<CreateMealList>
    {
        private readonly IMealListService _mealListService;

        public CreateMealListHandler(IMealListService mealListService)
        {
            _mealListService = mealListService;
        }

        public async Task HandleAsync(CreateMealList command)
        {
            await _mealListService.CreateAsync(command.Owner, command.Meals);
        }
    }
}
