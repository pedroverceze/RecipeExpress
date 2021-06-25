using RecipeExpressDomain.Abstract.Attributes;
using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Abstract.Enums;

namespace RecipeExpressDomain.Ingredients.Documents
{
    [BsonCollection("Ingredient")]
    public class IngredientDocument : Document
    {
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public decimal Amount { get; set; }
        public decimal Grams { get; set; }
        public bool Perishable { get; set; }
    }
}
