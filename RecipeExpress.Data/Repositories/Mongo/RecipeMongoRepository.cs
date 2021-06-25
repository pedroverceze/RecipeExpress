using RecipeExpressDomain.Abstract.Interfaces;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Repositories.Mongo
{
    public class RecipeMongoRepository : IRecipeMongoRepository
    {
        private readonly IMongoRepository<RecipeDocument> _mongoRepository;

        public RecipeMongoRepository(IMongoRepository<RecipeDocument> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task<RecipeDocument> GetRecipe(string id)
        {
            return await _mongoRepository.FindByIdAsync(id);
        }

        public async Task<List<RecipeDocument>> GetRecipes()
        {
            return await _mongoRepository.Find();
        }

        public async Task InsertRecipe(RecipeDocument document)
        {
            await _mongoRepository.InsertOneAsync(document);
        }
    }
}
