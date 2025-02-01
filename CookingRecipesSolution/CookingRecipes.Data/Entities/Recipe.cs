namespace CookingRecipes.Data.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PreparationTimeMinutes { get; set; }
        public int Servings { get; set; }

       
        public int CategoryId { get; set; }
        public Category Category { get; set; }

              public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
