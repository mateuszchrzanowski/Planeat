using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        //public Guid CreatedBy { get; protected set; }
        public Guid ProductListId { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Product()
        {
        }

        protected Product(string name, decimal price/*, Guid createdBy*/)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetPrice(price);
            //CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Product Create(string name, decimal price, ProductList productsList)
        {
            var product = new Product(name, price);

            productsList.AddProduct(product);

            return product;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Product name must not be empty.");
            }

            if (name.Length > 100)
            {
                throw new Exception("Email must not be longer than 100 characters.");
            }

            if (name == Name)
            {
                return;
            }

            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new Exception($"Product price must not be less than 0.");
            }

            if (price == Price)
            {
                return;
            }

            Price = price;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
