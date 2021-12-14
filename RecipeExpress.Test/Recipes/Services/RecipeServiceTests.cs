using Moq;
using RecipeExpressDomain.Recipes.Entities;
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

            _recipeEntityRepository.Verify();
        }

        [Fact]
        public async Task GetRecipe_ShouldBeSuccessful()
        {
            var doc = CreateRecipe();
            _recipeEntityRepository.Setup(s => s.GetRecipe(_recipeId)).ReturnsAsync(doc).Verifiable();

            var result = await _recipeService.GetRecipe(_recipeId);

            Assert.IsType<Recipe>(result);
            Assert.Equal(_recipeId, result.RecipeId);
            _recipeEntityRepository.Verify();
        }
    }
}
