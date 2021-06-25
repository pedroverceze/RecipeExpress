using RecipeExpressDomain.Client.Documents;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Client.Repositories
{
    public interface IClientMongoRepository
    {
        Task<ClientDocument> GetClient(string id);

        Task InsertClient(ClientDocument document);
    }
}
