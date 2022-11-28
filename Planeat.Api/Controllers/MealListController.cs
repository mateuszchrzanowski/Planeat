using Microsoft.AspNetCore.Mvc;
using Planeat.Infrastructure.Commands;
using Planeat.Infrastructure.DTO;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Api.Controllers
{
    public class MealListController : ApiControllerBase
    {
        private readonly IMealListService _mealListService;

        public MealListController(IMealListService mealListService,
            ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
            _mealListService = mealListService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<MealListDto> mealLists = await _mealListService.GetAllAsync();

            if (mealLists == null)
            {
                return NotFound();
            }

            return Ok(mealLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            MealListDto mealList = await _mealListService.GetAsync(id);

            if (mealList == null)
            {
                return NotFound();
            }

            return Ok(mealList);
        }
    }
}
