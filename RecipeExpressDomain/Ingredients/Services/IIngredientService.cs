using RecipeExpressDomain.Ingredients.Entities;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Services
{
    public interface IIngredientService
    {
        Task<Ingredient> EnrollIngredient(Ingredient ingredient);
    }
}