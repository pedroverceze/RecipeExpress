using RecipeExpressDomain.Recipes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Repositories
{
    public interface IRecipeEntityRepository
    {
        Task<Recipe> GetRecipe(Guid id);

        Task<List<Recipe>> GetRecipes();

        Task InsertRecipe(Recipe document);
    }
}
