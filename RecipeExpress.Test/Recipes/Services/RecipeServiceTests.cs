using Moq;
using RecipeExpressDomain.Recipes.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RecipeExpress.Test.Recipes.Services
{
    public class RecipeServiceTests : BaseRecipeTest
    {

        [Fact]
        public async Task EnrollRecipe_ShouldBeSuccessful()
        {
            var recipe = CreateRecipe();
            _recipeEntityRepository.Setup(s => s.InsertRecipe(recipe)).Returns(Task.CompletedTask).Verifiable();

            await _recipeService.EnrollRecipe(recipe);

            _recipeMongoRepository.Verify();
        }

        [Fact]
        public async Task GetRecipe_ShouldBeSuccessful()
        {
            var doc = CreateRecipeDocument();
            _recipeMongoRepository.Setup(s => s.GetRecipe(_recipeId.ToString())).ReturnsAsync(doc).Verifiable();

            var result = await _recipeService.GetRecipe(_recipeId);

            Assert.IsType<RecipeDocument>(result);
            Assert.Equal(_recipeId, result.Id);
            _recipeMongoRepository.Verify();
        }

        [Fact]
        public async Task GetRecipes_ShouldBeSuccessful()
        {
            var doc = CreateRecipeListDocument().ToList();
            _recipeMongoRepository.Setup(s => s.GetRecipes()).ReturnsAsync(doc).Verifiable();

            var result = await _recipeService.GetRecipes();

            Assert.IsType<List<RecipeDocument>>(result);
            _recipeMongoRepository.Verify();
        }
    }
}
