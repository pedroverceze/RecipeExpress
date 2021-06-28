using RecipeExpressDomain.Abstract.Attributes;
using RecipeExpressDomain.Abstract.Entities;
using System.Collections.Generic;

namespace RecipeExpressDomain.BuyList.Documents
{
    [BsonCollection("BuyList")]
    public class BuyListDocument : Document
    {
        public List<IndividualList> IndividualList { get; set; }
    }
}
