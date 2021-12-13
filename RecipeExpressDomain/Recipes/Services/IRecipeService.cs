using RecipeExpressDomain.Recipes.Entities;
using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Services
{
    public interface IRecipeService
    {
        Task EnrollRecipe(Recipe recipe);
        Task<Recipe> GetRecipe(Guid recipeId);
    }
}