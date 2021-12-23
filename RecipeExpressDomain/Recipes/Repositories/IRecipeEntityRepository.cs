using RecipeExpressDomain.Recipes.Entities;
using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Repositories
{
    public interface IRecipeEntityRepository
    {
        Task<Recipe> GetRecipe(Guid id);

        Task InsertRecipe(IRecipe document);
    }
}
