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
        Task<ShoppingList> GetAsync(Guid id);
        Task<ShoppingList> GetAsync(string name);
        Task AddAsync(ShoppingList shoppingList);
        Task UpdateAsync(ShoppingList shoppingList);
        Task RemoveAsync(Guid id);
    }
}
