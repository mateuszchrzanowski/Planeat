using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class ProductList
    {
        private ISet<Product> _products = new HashSet<Product>();

        public Guid Id { get; protected set; }
        public Guid OwnerId { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<Product> Products
        {
            get { return _products; }
            protected set { _products = new HashSet<Product>(value); }
        }

        protected ProductList()
        {
        }

        protected ProductList(User user)
        {
            Id = Guid.NewGuid();
            OwnerId = user.Id;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static ProductList Create(User user)
        {
            return new ProductList(user);
        }

        public void AddProduct(Product product)
        {
            var existingProduct = Products.SingleOrDefault(x => x.Name == product.Name);

            if (existingProduct != null)
            {
                throw new Exception($"Product with name '{product.Name}' already exists on this list.");
            }

            _products.Add(product);
            product.ProductListId = Id;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
