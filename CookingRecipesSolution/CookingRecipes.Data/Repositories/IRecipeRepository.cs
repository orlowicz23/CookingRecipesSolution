using System.Collections.Generic;
using CookingRecipes.Data.Entities;

namespace CookingRecipes.Data.Repositories
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAll();
        Recipe GetById(int id);
        void Add(Recipe recipe);
        void Update(Recipe recipe);
        void Delete(int id);
    }
}
