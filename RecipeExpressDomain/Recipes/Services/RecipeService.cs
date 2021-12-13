using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Entities;
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
        private readonly IRecipeEntityRepository _recipeEntityRepository;
        public RecipeService(IRecipeMongoRepository recipeRepository,
                            IRecipeEntityRepository recipeEntityRepository)
        {
            _recipeMongoRepository = recipeRepository;
            _recipeEntityRepository = recipeEntityRepository;
        }

        public async Task EnrollRecipe(Recipe recipe)
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

        public async Task<RecipeDocument> GetRecipe(Guid recipeId)
        {
            return await _recipeMongoRepository.GetRecipe(recipeId.ToString());
        }

        public async Task<List<RecipeDocument>> GetRecipes()
        {
            return await _recipeMongoRepository.GetRecipes();
        }
    }
}
