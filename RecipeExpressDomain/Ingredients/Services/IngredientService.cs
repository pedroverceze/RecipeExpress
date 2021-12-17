using RecipeExpressDomain.Abstract.Log;
using RecipeExpressDomain.Ingredients.Entities;
using RecipeExpressDomain.Ingredients.Exceptions;
using RecipeExpressDomain.Ingredients.Repositories;
using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientEntityRepository _ingredientEntityRepository;
        private readonly ILogService<Ingredient> _logService;
        public IngredientService(IIngredientEntityRepository ingredientEntityRepository, 
                                ILogService<Ingredient> logService)
        {
            _ingredientEntityRepository = ingredientEntityRepository;
            _logService = logService;
        }

        public async Task<Ingredient> EnrollIngredient(Ingredient ingredient)
        {
            try
            {
                await _ingredientEntityRepository.InsertIngredient(ingredient);

                await _logService.SaveLog(ingredient);

                return ingredient;
            }
            catch (Exception ext)
            {
                throw new FailToInsertIngredientException(ext.Message);
            }
        }

        public async Task<bool> CheckIngredientExists(string name)
        {
            var ingredient = await _ingredientEntityRepository.GetIngredient(name);

            return ingredient.IngredientId != Guid.Empty;
        }
    }
}
