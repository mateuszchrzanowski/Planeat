using Planeat.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Commands.Meals
{
    public class UpdateMeal : ICommand
    {
        public string Name { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }
    }
}
