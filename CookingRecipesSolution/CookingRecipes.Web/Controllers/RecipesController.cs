using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CookingRecipes.Data.Entities;
using CookingRecipes.Data.Repositories;

namespace CookingRecipes.Web.Controllers
{
    [Authorize]  // Możesz wymagać logowania do wszystkich akcji
    public class RecipesController : Controller
    {
        private readonly IRecipeRepository _recipeRepo;

        public RecipesController(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var recipes = _recipeRepo.GetAll();
            return View(recipes);
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var recipe = _recipeRepo.GetById(id);
            if (recipe == null) return NotFound();
            return View(recipe);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Recipe recipe)
        {
            if (!ModelState.IsValid)
                return View(recipe);

            _recipeRepo.Add(recipe);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var recipe = _recipeRepo.GetById(id);
            if (recipe == null) return NotFound();
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (!ModelState.IsValid)
                return View(recipe);

            _recipeRepo.Update(recipe);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _recipeRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
