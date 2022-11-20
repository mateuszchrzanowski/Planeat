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
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; protected set; }

        protected Product()
        {
        }

        public Product(string name, decimal price, Guid createdBy)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
