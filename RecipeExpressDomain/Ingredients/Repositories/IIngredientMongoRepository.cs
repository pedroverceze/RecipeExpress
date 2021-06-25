using RecipeExpressDomain.Ingredients.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Repositories
{
    public interface IIngredientMongoRepository
    {
        Task<IngredientDocument> GetIngredient(string id);

        Task InsertIngredient(IngredientDocument document);
    }
}
