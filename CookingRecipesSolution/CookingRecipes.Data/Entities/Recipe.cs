namespace CookingRecipes.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PreparationTimeMinutes { get; set; }
        public int Servings { get; set; }

        // Relacja do Category (1-n)
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Relacja wiele-do-wielu z Ingredient
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
