using System;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Clients.Entities;

namespace RecipeExpressDomain.Client.Repositories
{
    public interface IClientEntityRepository
    {
        Task InsertClient(c.Client document);
        Task<c.Client> GetClient(Guid clientId);
    }
}
