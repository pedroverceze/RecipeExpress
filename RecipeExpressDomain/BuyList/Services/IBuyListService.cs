using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Documents.Request;
using System.Threading.Tasks;

namespace RecipeExpressDomain.BuyList.Services
{
    public interface IBuyListService
    {
        Task<BuyListDocument> GetBuyList(string clientId);
        Task<BuyListDocument> RegisterBuyList(CreateBuyListDto createBuyListDto);
    }
}