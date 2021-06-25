using RecipeExpressDomain.Abstract.Attributes;
using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Ingredients.Documents;
using System.Collections.Generic;

namespace RecipeExpressDomain.BuyList.Documents
{
    [BsonCollection("BuyList")]
    public class BuyListDocument : Document
    {
        public List<IngredientDocument> Ingredients { get; set; }
    }
}
