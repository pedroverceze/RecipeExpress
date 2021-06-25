using RecipeExpressDomain.Abstract.Exceptions;
using RecipeExpressDomain.Ingredients.Documents;
using RecipeExpressDomain.Ingredients.Exceptions;
using RecipeExpressDomain.Ingredients.Repositories;
using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientMongoRepository _ingredientMongoRepository;
        public IngredientService(IIngredientMongoRepository ingredientRepository)
        {
            _ingredientMongoRepository = ingredientRepository;
        }

        public async Task EnrollIngredient(IngredientDocument ingredient)
        {
            try
            {
                await _ingredientMongoRepository.InsertIngredient(ingredient);
            }
            catch (Exception ext)
            {
                throw new FailToInsertIngredientException(ext.Message);
            }
        }
    }
}
