using RecipeExpress.Data.Repositories.Entity;
using RecipeExpressDomain.Client.Entities;
using RecipeExpressDomain.Client.Repositories;
using System;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Repositories.Mongo
{
    public class ClientEntityRepository : BaseRepository<Client>, IClientEntityRepository
    {
        public ClientEntityRepository(Context.Context context) : base(context)
        { }

        public Task<Client> GetClient(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public async Task InsertClient(Client client)
        {
            await _dbSet.AddAsync(client);
            _context.SaveChanges();
        }
    }
}
