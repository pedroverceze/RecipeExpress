using RecipeExpressDomain.Client.Repositories;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Exceptions;
using RecipeExpressDomain.Recipes.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeMongoRepository _recipeMongoRepository;
        public RecipeService(IRecipeMongoRepository recipeRepository)
        {
            _recipeMongoRepository = recipeRepository;
        }

        public async Task EnrollRecipe(RecipeDocument recipe)
        {
            try
            {
                await _recipeMongoRepository.InsertRecipe(recipe);
            }
            catch(Exception ext)
            {
                throw new FailToInsertRecipeException(ext.Message);
            }
        }

        public async Task<List<RecipeDocument>> GetRecipes()
        {
            return await _recipeMongoRepository.GetRecipes();
        }
    }
}
