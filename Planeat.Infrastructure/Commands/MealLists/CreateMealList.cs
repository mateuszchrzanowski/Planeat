using Planeat.Core.Domain;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Commands.MealLists
{
    public class CreateMealList : ICommand
    {
        public IEnumerable<Meal> Meals { get; set; }
        public Guid Owner { get; set; }
    }
}
