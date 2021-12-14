using RecipeExpressDomain.Client.Entities;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Client.Repositories
{
    public interface IClientRecipeRepository
    {
        Task AddClientRecipe(ClientRecipe clientRecipe);
    }
}
