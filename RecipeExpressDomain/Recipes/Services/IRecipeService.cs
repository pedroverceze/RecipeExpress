using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Services
{
    public interface IRecipeService
    {
        Task EnrollRecipe(Recipe recipe);
        Task<List<RecipeDocument>> GetRecipes();
        Task<RecipeDocument> GetRecipe(Guid recipeId);
    }
}