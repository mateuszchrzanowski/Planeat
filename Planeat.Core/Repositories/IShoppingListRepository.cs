using Planeat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Repositories
{
    public interface IShoppingListRepository
    {
        ShoppingList Get(Guid id);
        ShoppingList Get(string name);
        void Add(ShoppingList shoppingList);
        void Update(ShoppingList shoppingList);
        void Remove(Guid id);
    }
}
