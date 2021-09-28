using FluentAssertions;
using Moq;
using NUnit.Framework;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Repositories;
using RecipeExpressDomain.Recipes.Services;
using System;
using System.Threading.Tasks;

namespace RecipeExpress.Test.Recipes.Services
{
    public class RecipeServiceTests : BaseRecipeTest
    {
        private Mock<IRecipeMongoRepository> _recipeMongoRepository;
        private RecipeService _recipeService;

        [SetUp]
        public void Setup()
        {
            _recipeMongoRepository = new Mock<IRecipeMongoRepository>();
            _recipeService = new RecipeService(_recipeMongoRepository.Object);
        }

        [Test]
        public void EnrollRecipe_ShouldBeSuccessful()
        {
            var doc = CreateRecipeDocument();
            _recipeMongoRepository.Setup(s => s.InsertRecipe(doc)).Returns(Task.CompletedTask).Verifiable();

            Func<Task> act = async () => await _recipeService.EnrollRecipe(doc);

            act.Should().NotThrowAsync();
            _recipeMongoRepository.Verify();
        }

        [Test]
        public async Task GetRecipe_ShouldBeSuccessful()
        {
            var doc = CreateRecipeDocument();
            _recipeMongoRepository.Setup(s => s.GetRecipe(_recipeId.ToString())).ReturnsAsync(doc).Verifiable();

            var result = await _recipeService.GetRecipe(_recipeId);

            result.Should().BeOfType<RecipeDocument>();
            _recipeMongoRepository.Verify();
        }
    }
}
