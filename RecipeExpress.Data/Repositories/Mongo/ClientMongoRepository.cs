using RecipeExpressDomain.Abstract.Interfaces;
using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Repositories;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Repositories.Mongo
{
    public class ClientMongoRepository : IClientMongoRepository
    {
        private readonly IMongoRepository<ClientDocument> _mongoRepository;

        public ClientMongoRepository(IMongoRepository<ClientDocument> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task<ClientDocument> GetClient(string id)
        {
            return await _mongoRepository.FindByIdAsync(id);
        }

        public async Task InsertClient(ClientDocument document)
        {
            await _mongoRepository.InsertOneAsync(document);
        }
    }
}
