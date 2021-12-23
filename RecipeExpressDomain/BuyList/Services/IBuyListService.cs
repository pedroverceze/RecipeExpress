using RecipeExpressDomain.BuyList.Documents;
using System;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Clients.Entities;

namespace RecipeExpressDomain.BuyList.Services
{
    public interface IBuyListService
    {
        Task<BuyListDocument> GetBuyList(Guid clientId);
        Task RegisterBuyList(c.Client client);
    }
}