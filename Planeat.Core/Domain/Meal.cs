using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class Meal
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<Ingredient> Ingredients { get; protected set; }
        public decimal TotalPrice { get; protected set; }
    }
}
