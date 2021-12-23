using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Documents.Request;
using RecipeExpressDomain.BuyList.Repositories;
using RecipeExpressDomain.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Clients.Entities;

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

        public async Task<BuyListDocument> GetBuyList(Guid clientId)
        {
            return await _buyListRepository.GetBuyList(clientId);
        }

        public async Task RegisterBuyList(c.Client client)
        {
            var buyList = CreateBuyList(client);
            buyList.CreatedAt = DateTime.Now;

            await _buyListRepository.InsertBuyList(buyList);
        }

        private BuyListDocument CreateBuyList(c.Client client)
        {
            var buyList = new BuyListDocument()
            {
                IndividualList = new List<IndividualList>()
            };

            var recipes = client.Recipes;

            //if (recipes is null || recipes.Count <= 0)
            //{
            //    throw new ClientWithoutRecipesException("Client have no recipes.");
            //}

            //TODO: precisa adicionar os Ingredients na entidade recipe e criar o relacionamento n -> n
            //var total = recipes.SelectMany(x => x.Ingredients)
            //.GroupBy(i => i.Name)
            //.Select(g => new { Name = g.Key, Grams = g.Sum(x => x.), Amount = g.Sum(x => x.Amount) }).ToList();

            //foreach (var item in total)
            //{
            //    var individual = new IndividualList
            //    {
            //        Name = item.Name,
            //        Amount = item.Amount,
            //        Grams = item.Grams
            //    };

            //    buyList.IndividualList.Add(individual);
            //};

            return buyList;
        }
    }
}
