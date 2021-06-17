using RecipeExpress.Data.Context;
using RecipeExpressDomain.Client.Entities;
using RecipeExpressDomain.Client.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecipeExpress.Data.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context)
        { }

        public async Task<bool> EnrollClient(Client client)
        {
            var alreadyExists = Filter(client.ClientId).Any();
            if (alreadyExists)
            {
                _dbSet.Attach(client);
            }
            else
            {
                await _dbSet.AddAsync(client);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Client> GetClient(Guid clientId)
        => await Filter(clientId).FirstOrDefaultAsync();

        private IQueryable<Client> Filter(Guid clientId)
            => _dbSet.Where(client => client.ClientId == clientId);
    }
}

