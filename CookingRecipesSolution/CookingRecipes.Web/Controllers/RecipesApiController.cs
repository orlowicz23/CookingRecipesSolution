using Microsoft.AspNetCore.Mvc;
using CookingRecipes.Data.Entities;
using CookingRecipes.Data.Repositories;

namespace CookingRecipes.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesApiController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepo;

        public RecipesApiController(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var recipes = _recipeRepo.GetAll();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var recipe = _recipeRepo.GetById(id);
            if (recipe == null) return NotFound();
            return Ok(recipe);
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            _recipeRepo.Add(recipe);
            return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Recipe recipe)
        {
            if (id != recipe.Id) return BadRequest();

            var existing = _recipeRepo.GetById(id);
            if (existing == null) return NotFound();

            _recipeRepo.Update(recipe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _recipeRepo.GetById(id);
            if (existing == null) return NotFound();

            _recipeRepo.Delete(id);
            return NoContent();
        }
    }
}
