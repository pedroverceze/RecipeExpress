using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Repositories;
using RecipeExpressDomain.Client.Services;
using RecipeExpressDomain.Ingredients.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeExpressDomain.BuyList.Services
{
    public class BuyListService : IBuyListService
    {
        private readonly IClientService _clientService;
        private readonly IBuyListRepository _buyListRepository;

        public BuyListService(IClientService clientService,
                              IBuyListRepository buyListRepository)
        {
            _clientService = clientService;
            _buyListRepository = buyListRepository;
        }

        public async Task CreateBuyList(Guid clientId)
        {
            var client = await _clientService.GetClient(clientId);

            var recipes = client.Recipes;
            var buyList = new BuyListDocument()
            {
                IndividualList = new List<IndividualList>()
            };


            foreach (var item in recipes)
            {
                buyList.IndividualList.AddRange(CreateItemList(item.Ingredients));
            }

            await _buyListRepository.InsertBuyList(buyList);
        }

        private List<IndividualList> CreateItemList(List<IngredientDocument> ingredients)
        {
            var ingredientList = new List<IndividualList>();

            foreach (var item in ingredients)
            {
                ingredientList.Add(
                   new IndividualList
                   {
                       Name = item.Name,
                       Amount = item.Amount,
                       Grams = item.Grams
                   });
            }

            return ingredientList;
        }
    }
}
