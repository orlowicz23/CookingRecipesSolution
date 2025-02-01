using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CookingRecipes.Data;
using CookingRecipes.Data.Entities;
using CookingRecipes.Data.Repositories;

namespace CookingRecipes.Tests
{
    [TestFixture]
    public class RecipeRepositoryTests
    {
        private CookingDbContext _context;
        private RecipeRepository _repo;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<CookingDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new CookingDbContext(options);
            _repo = new RecipeRepository(_context);
        }

        [Test]
        public void Add_Recipe_ShouldIncreaseCount()
        {
           
            var recipe = new Recipe { Title = "Szarlotka", Servings = 8 };
            _repo.Add(recipe);
            Assert.AreEqual(1, _repo.GetAll().Count());
        }
    }
}
