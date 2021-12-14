using RecipeExpressDomain.Abstract.Entities;
using System;
using System.Collections.Generic;

namespace RecipeExpressDomain.Client.Entities
{
    public class Client : EntityBase
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<ClientRecipe> ClientRecipes { get; set; } = new List<ClientRecipe>();
    }
}
