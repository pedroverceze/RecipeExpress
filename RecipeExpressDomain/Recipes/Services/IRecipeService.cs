using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Services
{
    public interface IRecipeService
    {
        Task EnrollRecipe(RecipeDocument recipe);
        Task<List<RecipeDocument>> GetRecipes();
    }
}