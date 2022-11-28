using Planeat.Core.Domain;
using Planeat.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.Repositories
{
    public class InMemoryMealListRepository : IMealListRepository
    {
        private static ISet<MealList> _mealLists = new HashSet<MealList>
        {
            new MealList(new List<Meal>
            {
                new Meal("Pizza", new List<Ingredient>
                {
                    new Ingredient(new Guid("b24d8d8e-19e4-4dd5-9c11-cc791654f55f"),
                        "Pizza Douch",
                        1,
                        7.13M),
                    new Ingredient(new Guid("b45898c0-5bf6-43a8-9898-c18fd28d491b"),
                        "Flour",
                        1,
                        2.75M),
                }, new Guid()),
                new Meal("Tomato soup", new List<Ingredient>
                {
                    new Ingredient(new Guid("ea357467-90e4-48fa-a93b-b078fe8d6a55"),
                        "Sugar",
                        1,
                        4.99M),
                }, new Guid()),
            }, new Guid("1bf497b1-46ad-4932-afd5-24a2f0a219a8")),
            new MealList(new List<Meal>
            {
                new Meal("Carbonara", new List<Ingredient>
                {
                    new Ingredient(new Guid("acc660c9-fff8-4328-9031-9cd5da450062"),
                        "Pasta",
                        1,
                        5.47M),
                }, new Guid()),
            }, new Guid("aab9e0c9-effa-4f41-a534-3624fcf01006")),
        };

        public Task CreateAsync(Guid owner, IEnumerable<Meal> meals)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MealList>> GetAllAsync()
        {
            IEnumerable<MealList> mealLists = await Task.FromResult(_mealLists);
            return mealLists;
        }

        public async Task<MealList> GetAsync(Guid id)
        {
            MealList mealList = await Task.FromResult(_mealLists.SingleOrDefault(m => m.Id == id));
            return mealList;
        }
    }
}
