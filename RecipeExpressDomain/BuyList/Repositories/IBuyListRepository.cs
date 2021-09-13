using RecipeExpressDomain.BuyList.Documents;
using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.BuyList.Repositories
{
    public interface IBuyListRepository
    {
        Task<BuyListDocument> GetBuyList(Guid id);
        Task InsertBuyList(BuyListDocument document);
        Task UpdateBuyList(BuyListDocument document);
    }
}
