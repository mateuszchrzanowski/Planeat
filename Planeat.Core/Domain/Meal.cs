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
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected Meal()
        {
        }

        public Meal(string name, IEnumerable<Ingredient> ingredients, Guid createdBy)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetIngredients(ingredients);
            TotalPrice = CalculateTotalPrice();
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Meal name can not be empty.");
            }

            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetIngredients(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
            CalculateTotalPrice();

            UpdatedAt = DateTime.UtcNow;
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
