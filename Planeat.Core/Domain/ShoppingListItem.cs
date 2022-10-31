using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class ShoppingListItem
    {
        public Guid Id { get; protected set; }
        public Guid ProductId { get; protected set; }
        public string Name { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal ProductPrice { get; protected set; }

        protected ShoppingListItem()
        {
        }

        public ShoppingListItem(Guid productId, string name, int quantity, decimal productPrice)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Name = name;
            Quantity = quantity;
            ProductPrice = productPrice;
        }

        public decimal GetSummaryPrice()
        {
            decimal summaryPrice = ProductPrice * Quantity;
            return summaryPrice;
        }
    }
}
