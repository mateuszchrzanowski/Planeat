using Planeat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.DTO
{
    public class MealListDto
    {
        public Guid Id { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public Guid Owner { get; set; }
    }
}
