using System;
using System.Threading.Tasks;

namespace RecipeExpressDomain.BuyList.Services
{
    public interface IBuyListService
    {
        Task CreateBuyList(Guid clientId);
    }
}