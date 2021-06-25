using RecipeExpressDomain.Client.Documents;
using System.Threading.Tasks;

namespace RecipeExpressDomain.BuyList.Services
{
    public interface IBuyListService
    {
        Task CreateBuyList(ClientDocument client);
    }
}