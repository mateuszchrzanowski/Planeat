using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.DTO
{
    public class MealDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }
    }
}
