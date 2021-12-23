using RecipeExpressDomain.Recipes.Entities;
using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Services
{
    public interface IRecipeService
    {
        Task EnrollRecipe(IRecipe recipe);
        Task<Recipe> GetRecipe(Guid recipeId);
    }
}