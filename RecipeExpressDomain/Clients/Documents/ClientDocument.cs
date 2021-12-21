using RecipeExpressDomain.Abstract.Attributes;
using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Recipes.Documents;
using System.Collections.Generic;

namespace RecipeExpressDomain.Client.Documents
{
    [BsonCollection("Client")]
    public class ClientDocument : Document
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }

        public List<RecipeDocument> Recipes { get; set; }
    }
}
