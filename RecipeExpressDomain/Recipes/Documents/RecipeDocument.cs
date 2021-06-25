using RecipeExpressDomain.Abstract.Attributes;
using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Ingredients.Documents;
using System.Collections.Generic;

namespace RecipeExpressDomain.Recipes.Documents
{
    [BsonCollection("Recipe")]
    public class RecipeDocument : Document
    {
        public string Name { get; set; }
        public int Dificult { get; set; }
        public string PrepareMode { get; set; }
        public List<IngredientDocument> Ingredients { get; set; }
    }
}
