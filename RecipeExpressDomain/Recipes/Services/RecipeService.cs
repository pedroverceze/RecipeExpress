using RecipeExpressDomain.Client.Repositories;
using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IClientRepository _clientRepository;
        public RecipeService(IRecipeRepository recipeRepository,
                            IClientRepository clientRepository)
        {
            _recipeRepository = recipeRepository;
            _clientRepository = clientRepository;
        }

        public async Task EnrollRecipe(Recipe recipe)
        {
            var client = await _clientRepository.GetClient(recipe.ClientId);

            if(client is null)
            {
                throw new Exception("Necessario se cadastrar");
            }

            if (!await _recipeRepository.EnrollRecipe(recipe))
            {
                throw new Exception();
            }
        }
    }
}
