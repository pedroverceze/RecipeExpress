using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Abstract.Enums;
using RecipeExpressDomain.Recipes.Entities;
using System;
using System.Collections.Generic;

namespace RecipeExpressDomain.Ingredients.Entities
{
    public class Ingredient : EntityBase
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public bool Perishable { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
