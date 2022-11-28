using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class MealList
    {
        public Guid Id { get; protected set; }
        public IEnumerable<Meal> Meals { get; protected set; }
        public Guid Owner { get; protected set; }

        protected MealList()
        {
        }

        public MealList(IEnumerable<Meal> meals, Guid owner)
        {
            Id = Guid.NewGuid();
            Meals = meals;
            Owner = owner;
        }
    }
}
