using RecipeExpressDomain.Client.Documents;
using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Client.Services
{
    public interface IClientService
    {
        Task EnrollClient(ClientDocument client);
        Task EnrollRecipe(Guid clientId, Guid recipeId);
    }
}