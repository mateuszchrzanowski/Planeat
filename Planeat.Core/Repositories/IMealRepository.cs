using Planeat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Core.Repositories
{
    public interface IMealRepository
    {
        Meal Get(Guid id);
        Meal Get(string name);
        void Add(Meal meal);
        void Update(Meal meal);
        void Remove(Guid id);
    }
}
