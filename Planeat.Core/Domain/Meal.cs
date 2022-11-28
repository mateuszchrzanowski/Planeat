using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Domain
{
    public class Meal
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public decimal TotalPrice { get; protected set; }
        public Guid CreatedBy { get; protected set; }

        protected Meal()
        {
        }

        public Meal(string name, IEnumerable<Ingredient> ingredients, Guid createdBy)
        {
            Id = Guid.NewGuid();
            Name = name;
            SetIngredients(ingredients);
            TotalPrice = CalculateTotalPrice();
            CreatedBy = createdBy;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Meal name can not be empty.");
            }

            Name = name;
        }

        public void SetIngredients(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
            CalculateTotalPrice();
        }

        private decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            if (Ingredients != null)
            {
                foreach (Ingredient ingredient in Ingredients)
                {
                    totalPrice += ingredient.GetSummaryPrice();
                } 
            }

            return totalPrice;
        }
    }
}
