using RecipeExpressDomain.Ingredients.Entities;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Repositories
{
    public interface IIngredientEntityRepository
    {
        Task InsertIngredient(Ingredient ingredient);
    }
}
