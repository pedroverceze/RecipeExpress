using RecipeExpressDomain.Recipes.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Repositories
{
    public interface IRecipeMongoRepository
    {
        Task<RecipeDocument> GetRecipe(string id);

        Task<List<RecipeDocument>> GetRecipes();

        Task InsertRecipe(RecipeDocument document);
    }
}
