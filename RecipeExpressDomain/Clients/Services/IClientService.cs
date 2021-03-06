using System;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Clients.Entities;

namespace RecipeExpressDomain.Client.Services
{
    public interface IClientService
    {
        Task EnrollClient(c.Client client);
        Task AddRecipe(Guid recipeId, Guid clientId);
        Task<c.Client> GetClient(Guid clientId);
    }
}