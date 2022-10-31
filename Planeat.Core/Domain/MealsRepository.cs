using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class MealsRepository
    {
        public IEnumerable<Meal> Meals { get; protected set; }

        protected MealsRepository()
        {
        }

        public MealsRepository(IEnumerable<Meal> meals)
        {
            Meals = meals;
        }
    }
}
