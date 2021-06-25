using RecipeExpressDomain.Ingredients.Entities;
using RecipeExpressDomain.Ingredients.Repositories;
using RecipeExpressDomain.Ingredients.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task EnrollIngredient(Ingredient ingredient)
        {
            if (!await _ingredientRepository.EnrollIngredient(ingredient))
            {
                throw new Exception("Erro ao cadastrar");
            }
        }
    }
}
