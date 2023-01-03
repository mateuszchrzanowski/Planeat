using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Commands.Products
{
    public class CreateProduct : ICommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid ProductListId { get; set; }
    }
}
