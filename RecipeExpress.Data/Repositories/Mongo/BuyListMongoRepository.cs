using RecipeExpressDomain.Abstract.Interfaces;
using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<BuyListDocument> GetBuyList(Guid id)
        {
            Expression<Func<BuyListDocument, bool>> func = x => x.ClientId == id;
            var result = await _mongoRepository.Find(func);

            return result.OrderByDescending(c => c.CreatedAt).FirstOrDefault();
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
