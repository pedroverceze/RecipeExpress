using RecipeExpressDomain.Recipes.Entities;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Services
{
    public interface IRecipeService
    {
        Task EnrollRecipe(Recipe recipe);
    }
}