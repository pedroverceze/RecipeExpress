using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Abstract.Enums;
using System;

namespace RecipeExpressDomain.Ingredients.Entities
{
    public class Ingredient : EntityBase
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public bool Perishable { get; set; }
    }
}
