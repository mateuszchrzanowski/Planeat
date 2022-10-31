using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class MealsList
    {
        public IEnumerable<Meal> Meals { get; protected set; }

        protected MealsList()
        {
        }

        public MealsList(IEnumerable<Meal> meals)
        {
            Meals = meals;
        }
    }
}
