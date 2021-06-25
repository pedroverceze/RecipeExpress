using RecipeExpressDomain.Abstract.Interfaces;
using RecipeExpressDomain.Ingredients.Documents;
using RecipeExpressDomain.Ingredients.Repositories;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Repositories.Mongo
{
    public class IngredientMongoRepository : IIngredientMongoRepository
    {
        private readonly IMongoRepository<IngredientDocument> _mongoRepository;

        public IngredientMongoRepository(IMongoRepository<IngredientDocument> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task<IngredientDocument> GetIngredient(string id)
        {
            return await _mongoRepository.FindByIdAsync(id);
        }

        public async Task InsertIngredient(IngredientDocument document)
        {
            await _mongoRepository.InsertOneAsync(document);
        }
    }
}
