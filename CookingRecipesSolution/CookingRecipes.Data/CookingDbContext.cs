using Microsoft.EntityFrameworkCore;
using CookingRecipes.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CookingRecipes.Data
{
    // Jeśli używasz Identity, dziedzicz po IdentityDbContext
    // (podając własne klasy ApplicationUser, ApplicationRole, jeśli potrzebne)
    public class CookingDbContext : DbContext
    {
        public CookingDbContext(DbContextOptions<CookingDbContext> options)
            : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Klucz łączący w tabeli RecipeIngredient
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });
        }
    }
}
