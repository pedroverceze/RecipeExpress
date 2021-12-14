using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Recipes.Entities;
using System;

namespace RecipeExpressDomain.Client.Entities
{
    public class ClientRecipe : EntityBase
    {
        public Guid ClientId { get; set; }
        public Guid RecipeId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
