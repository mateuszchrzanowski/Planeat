using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class ShoppingList
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<ShoppingListItem> Items { get; protected set; }
        public decimal TotalPrice { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public bool IsActive { get; protected set; }

        protected ShoppingList()
        {
        }

        public ShoppingList(string name, IEnumerable<ShoppingListItem> items, bool isActive)
        {
            Id = Guid.NewGuid();
            Name = name;
            Items = items;
            TotalPrice = CalculateTotalPrice();
            CreatedAt = DateTime.UtcNow;
            IsActive = isActive;
        }

        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            return totalPrice;
        }
    }
}
