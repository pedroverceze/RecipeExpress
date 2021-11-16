using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Repositories;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Client.Entities;

namespace RecipeExpressDomain.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientMongoRepository _clientMongoRepository;
        private readonly IClientEntityRepository _clientEntityRepository;
        private readonly IRecipeService _recipeService;

        public ClientService(IClientMongoRepository clientMongoRepository,
                             IRecipeService recipeService,
                             IClientEntityRepository clientEntityRepository)
        {
            _clientMongoRepository = clientMongoRepository;
            _recipeService = recipeService;
            _clientEntityRepository = clientEntityRepository;
        }

        public async Task EnrollClient(c.Client client)
        {
            await _clientEntityRepository.InsertClient(client);
        }

        public async Task EnrollRecipe(ClientRecipe clientRecipe)
        {
            var client = await _clientMongoRepository.GetClient(clientRecipe.ClientId.ToString());

            var recipe = await _recipeService.GetRecipe(clientRecipe.RecipeId);

            if (client.Recipes is null || client.Recipes.Count <= 0)
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

        public async Task<ClientDocument> GetClient(Guid clientId)
        {
            return await _clientMongoRepository.GetClient(clientId.ToString());
        }
    }
}
