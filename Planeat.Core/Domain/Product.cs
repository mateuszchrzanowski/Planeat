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
        public Guid CreatedBy { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Product()
        {
        }

        public Product(string name, decimal price, Guid createdBy)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetPrice(price);
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Product name can not be empty.");
            }

            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
            {
                throw new Exception($"Product price can not be less than 0.");
            }

            Price = price;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
