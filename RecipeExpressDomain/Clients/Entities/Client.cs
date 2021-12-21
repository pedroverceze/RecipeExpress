using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Recipes.Entities;
using System;
using System.Collections.Generic;

namespace RecipeExpressDomain.Clients.Entities
{
    public class Client : EntityBase
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
