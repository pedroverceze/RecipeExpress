using System.Threading.Tasks;
using c = RecipeExpressDomain.Client.Entities;

namespace RecipeExpressDomain.Client.Repositories
{
    public interface IClientEntityRepository
    {
        Task InsertClient(c.Client document);
    }
}
