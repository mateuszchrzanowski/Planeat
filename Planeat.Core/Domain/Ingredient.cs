using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class Ingredient
    {
        public Guid ProductId { get; protected set; }
        public string Name { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal ProductPrice { get; set; }
        public DateTime UpdatedAt { get; set; }

        protected Ingredient()
        {
        }

        public Ingredient(Guid productId, string name, int quantity, decimal productPrice)
        {
            ProductId = productId;
            SetName(name);
            SetQuantity(quantity);
            ProductPrice = productPrice;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Ingredient name can not be empty.");
            }

            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception("Ingredient quantity must be greater than 0.");
            }

            Quantity = quantity;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetProductPrice(decimal productPrice)
        {
            if (productPrice <= 0)
            {
                throw new Exception("Product price must be greater than 0.");
            }

            ProductPrice = productPrice;
            UpdatedAt = DateTime.UtcNow;
        }

        public decimal GetSummaryPrice()
        {
            decimal summaryPrice = ProductPrice * Quantity;
            return summaryPrice;
        }
    }
}
