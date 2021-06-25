using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Repositories;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientMongoRepository _clientMongoRepository;
        private readonly IRecipeService _recipeService;

        public ClientService(IClientMongoRepository clientMongoRepository,
                             IRecipeService recipeService)
        {
            _clientMongoRepository = clientMongoRepository;
            _recipeService = recipeService;
        }

        public async Task EnrollClient(ClientDocument client)
        {
            await _clientMongoRepository.InsertClient(client);
        }

        public async Task EnrollRecipe(Guid clientId, Guid recipeId)
        {
            var client = await _clientMongoRepository.GetClient(clientId.ToString());

            var recipe = await _recipeService.GetRecipe(recipeId);

            if (client.Recipes.Count <= 0)
            {
                client.Recipes = new List<RecipeDocument>
                {
                    recipe
                };
            }
            else
            {
                client.Recipes.Add(recipe);
            }

            await _clientMongoRepository.UpdateClient(client);
        }
    }
}
