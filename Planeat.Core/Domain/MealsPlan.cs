using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class MealsPlan
    {
        public Guid Id { get; set; }
        public IEnumerable<Meal> Meals { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }

        protected MealsPlan()
        {
        }

        public MealsPlan(IEnumerable<Meal> meals, DateTime startDate, DateTime endDate)
        {
            Id = Guid.NewGuid();
            Meals = meals;
            CreatedAt = DateTime.UtcNow;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
