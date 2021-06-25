using RecipeExpressDomain.Recipes.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Services
{
    public interface IRecipeService
    {
        Task EnrollRecipe(RecipeDocument recipe);
        Task<List<RecipeDocument>> GetRecipes();
        Task<RecipeDocument> GetRecipe(Guid recipeId);
    }
}