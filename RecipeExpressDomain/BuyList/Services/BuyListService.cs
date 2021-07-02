using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Exceptions;
using RecipeExpressDomain.BuyList.Repositories;
using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var buyList = CreateBuyList(client);
            buyList.CreatedAt = DateTime.Now;

            await _buyListRepository.InsertBuyList(buyList);
        }

        private BuyListDocument CreateBuyList(ClientDocument clientDocument)
        {
            var buyList = new BuyListDocument()
            {
                IndividualList = new List<IndividualList>()
            };


            var recipes = clientDocument.Recipes;

            if(recipes is null || recipes.Count <= 0)
            {
                throw new ClientWithoutRecipesException("Client have no recipes.");
            }

            var total = recipes.SelectMany(x => x.Ingredients)
            .GroupBy(i => i.Name)
            .Select(g => new { Name = g.Key, Grams = g.Sum(x => x.Grams), Amount = g.Sum(x => x.Amount) }).ToList();


            foreach (var item in total)
            {
                var individual = new IndividualList
                {
                    Name = item.Name,
                    Amount = item.Amount,
                    Grams = item.Grams
                };

                buyList.IndividualList.Add(individual);
            };

            return buyList;
        }
    }
}
