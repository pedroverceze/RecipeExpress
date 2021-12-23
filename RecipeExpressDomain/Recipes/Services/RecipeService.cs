using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Exceptions;
using RecipeExpressDomain.Recipes.Repositories;
using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeEntityRepository _recipeEntityRepository;
        public RecipeService(IRecipeEntityRepository recipeEntityRepository)
        {
            _recipeEntityRepository = recipeEntityRepository;
        }

        public async Task EnrollRecipe(IRecipe recipe)
        {
            try
            {
                await _recipeEntityRepository.InsertRecipe(recipe);
            }
            catch (Exception ext)
            {
                throw new FailToInsertRecipeException(ext.Message);
            }
        }

        public async Task<Recipe> GetRecipe(Guid recipeId)
        {
            return await _recipeEntityRepository.GetRecipe(recipeId);
        }
    }
}
