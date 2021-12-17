using RecipeExpressDomain.Client.Entities;
using RecipeExpressDomain.Client.Repositories;
using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Client.Entities;

namespace RecipeExpressDomain.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientEntityRepository _clientEntityRepository;
        private readonly IRecipeService _recipeService;

        public ClientService(IRecipeService recipeService,
                             IClientEntityRepository clientEntityRepository)
        {
            _recipeService = recipeService;
            _clientEntityRepository = clientEntityRepository;
        }

        public async Task AddRecipe(Guid recipeId, Guid clientId)
        {
            var client = await _clientEntityRepository.GetClient(clientId);
            var recipe = await _recipeService.GetRecipe(recipeId);

            client.Recipes = new List<Recipe>
            {
                recipe
            };

            await _clientEntityRepository.InsertClient(client);
        }

        public async Task EnrollClient(c.Client client)
        {
            await _clientEntityRepository.InsertClient(client);
        }
        

        public async Task<c.Client> GetClient(Guid clientId)
        {
            return await _clientEntityRepository.GetClient(clientId);
        }
    }
}
