using RecipeExpressDomain.Abstract.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Client.Entities;

namespace RecipeExpressDomain.Recipes.Entities
{
    public class Recipe : EntityBase
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
        public int Dificult { get; set; }
        public string PrepareMode { get; set; }
        public Guid ClientId { get; set; }
        public string CreatedBy { get; set; }
    }
}
