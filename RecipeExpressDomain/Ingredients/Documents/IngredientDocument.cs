using RecipeExpressDomain.Abstract.Attributes;
using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Abstract.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Documents
{
    [BsonCollection("Ingredient")]
    public class IngredientDocument : Document
    {
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public bool Perishable { get; set; }
    }
}
