using RecipeExpressDomain.Abstract.Interfaces;
using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Repositories;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Repositories.Mongo
{
    public class BuyListMongoRepository : IBuyListRepository
    {
        private readonly IMongoRepository<BuyListDocument> _mongoRepository;

        public BuyListMongoRepository(IMongoRepository<BuyListDocument> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task<BuyListDocument> GetBuyList(string id)
        {
            return await _mongoRepository.FindByIdAsync(id);
        }

        public async Task InsertBuyList(BuyListDocument document)
        {
            await _mongoRepository.InsertOneAsync(document);
        }

        public async Task UpdateBuyList(BuyListDocument document)
        {
            await _mongoRepository.ReplaceOneAsync(document);
        }
    }
}
