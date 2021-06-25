using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Ingredients.Documents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeExpressDomain.BuyList.Services
{
    public class BuyListService : IBuyListService
    {
        public async Task CreateBuyList(ClientDocument client)
        {
            var recipe = client.Recipes;

            List<IngredientDocument> ingredients = new List<IngredientDocument>();

            //foreach(var item in client.Recipes)
            //{
            //    var am = item.Ingredients.Where(i => i.Id )
            //}
        }
    }
}
