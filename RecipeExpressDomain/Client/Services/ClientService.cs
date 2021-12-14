using RecipeExpressDomain.Client.Entities;
using RecipeExpressDomain.Client.Repositories;
using RecipeExpressDomain.Recipes.Services;
using System;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Client.Entities;

namespace RecipeExpressDomain.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientEntityRepository _clientEntityRepository;
        private readonly IRecipeService _recipeService;
        private readonly IClientRecipeRepository _clientRecipeRepository;

        public ClientService(IRecipeService recipeService,
                             IClientEntityRepository clientEntityRepository,
                             IClientRecipeRepository clientRecipeRepository)
        {
            _recipeService = recipeService;
            _clientEntityRepository = clientEntityRepository;
            _clientRecipeRepository = clientRecipeRepository;
        }

        public async Task EnrollClient(c.Client client)
        {
            await _clientEntityRepository.InsertClient(client);
        }

        public async Task EnrollRecipe(ClientRecipe clientRecipe)
        {
            await _clientRecipeRepository.AddClientRecipe(clientRecipe);
        }

        public async Task<c.Client> GetClient(Guid clientId)
        {
            return await _clientEntityRepository.GetClient(clientId);
        }
    }
}
