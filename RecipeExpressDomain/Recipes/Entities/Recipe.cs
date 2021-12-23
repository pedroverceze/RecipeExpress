using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Abstract.Enums;
using RecipeExpressDomain.Clients.Entities;
using RecipeExpressDomain.Ingredients.Entities;
using System;
using System.Collections.Generic;
using c = RecipeExpressDomain.Clients.Entities;

namespace RecipeExpressDomain.Recipes.Entities
{
    public class Recipe : EntityBase, IRecipe
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
        public Difficult Dificult { get; set; }
        public string PrepareMode { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<c.Client> Clients { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
