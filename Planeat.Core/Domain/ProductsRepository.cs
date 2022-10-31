using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class ProductsRepository
    {
        public IEnumerable<Product> Products { get; protected set; }

        protected ProductsRepository()
        {
        }

        public ProductsRepository(IEnumerable<Product> products)
        {
            Products = products;
        }
    }
}
