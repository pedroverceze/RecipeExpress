using RecipeExpress.Data.Repositories.Entity;
using RecipeExpressDomain.Client.Entities;
using RecipeExpressDomain.Client.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Repositories.Mongo
{
    public class ClientEntityRepository : BaseRepository<Client>, IClientEntityRepository
    {
        public ClientEntityRepository(Context.Context context) : base(context)
        { }

        public async Task<Client> GetClient(Guid clientId)
        {
            return Filter(clientId)
                .FirstOrDefault();
        }

        public async Task InsertClient(Client client)
        {
            try
            {
                var cli = Filter(client.ClientId);

                if (cli is not null)
                {
                    _dbSet.Append(client);
                }
                else
                {
                    await _dbSet.AddAsync(client);
                }

                _context.SaveChanges();
            }catch(Exception ext)
            {
                var msg = ext.Message;
                throw;
            }
        }

        private IQueryable<Client> Filter(Guid clientId)
        {
            return _dbSet.Where(c => c.ClientId == clientId);
        }
    }
}
