using RecipeExpressDomain.Ingredients.Documents;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Services
{
    public interface IIngredientService
    {
        Task<IngredientDocument> EnrollIngredient(IngredientDocument ingredient);
    }
}