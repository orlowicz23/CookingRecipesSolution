using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CookingRecipes.Data.Entities;

namespace CookingRecipes.Data.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CookingDbContext _db;

        public RecipeRepository(CookingDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _db.Recipes
                      .Include(r => r.Category)
                      .Include(r => r.RecipeIngredients)
                      .ThenInclude(ri => ri.Ingredient)
                      .ToList();
        }

        public Recipe GetById(int id)
        {
            return _db.Recipes
                      .Include(r => r.Category)
                      .Include(r => r.RecipeIngredients)
                      .ThenInclude(ri => ri.Ingredient)
                      .FirstOrDefault(r => r.Id == id);
        }

        public void Add(Recipe recipe)
        {
            _db.Recipes.Add(recipe);
            _db.SaveChanges();
        }

        public void Update(Recipe recipe)
        {
            _db.Recipes.Update(recipe);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var recipe = _db.Recipes.Find(id);
            if (recipe != null)
            {
                _db.Recipes.Remove(recipe);
                _db.SaveChanges();
            }
        }
    }
}
