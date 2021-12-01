using RecipeExpressDomain.Ingredients.Entities;
using RecipeExpressDomain.Ingredients.Exceptions;
using RecipeExpressDomain.Ingredients.Repositories;
using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientMongoRepository _ingredientMongoRepository;
        private readonly IIngredientEntityRepository _ingredientEntityRepository;

        public IngredientService(IIngredientMongoRepository ingredientRepository,
                                 IIngredientEntityRepository ingredientEntityRepository)
        {
            _ingredientMongoRepository = ingredientRepository;
            _ingredientEntityRepository = ingredientEntityRepository;
        }

        public async Task<Ingredient> EnrollIngredient(Ingredient ingredient)
        {
            try
            {
                await _ingredientEntityRepository.InsertIngredient(ingredient);

                return ingredient;
            }
            catch (Exception ext)
            {
                throw new FailToInsertIngredientException(ext.Message);
            }
        }

        public async Task<bool> CheckIngredientExists(string name)
        {
            var ingredient = await _ingredientMongoRepository.GetIngredient(name);

            return ingredient.Id != Guid.Empty;
        }
    }
}
