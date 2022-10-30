using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class Ingredient
    {
        public Guid Id { get; protected set; }
        public Guid ProductId { get; protected set; }
        public string Name { get; protected set; }
        public int Quantity { get; protected set; }
    }
}
