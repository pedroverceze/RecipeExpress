using RecipeExpressDomain.Client.Entities;
using RecipeExpressDomain.Client.Repositories;
using System.Threading.Tasks;
using c = RecipeExpress.Data.Context;

namespace RecipeExpress.Data.Repositories.Entity
{
    public class ClientRecipeRepository : BaseRepository<ClientRecipe>, IClientRecipeRepository
    {
        public ClientRecipeRepository(c.Context context) : base(context)
        { }

        public Task AddClientRecipe(ClientRecipe clientRecipe)
        {
            throw new System.NotImplementedException();
        }
    }
}
