using RecipeExpressDomain.Abstract.Entities;
using System;

namespace RecipeExpressDomain.Recipes.Entities
{
    public class Recipe : EntityBase
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
        public int Dificult { get; set; }
        public string PrepareMode { get; set; }
        public string CreatedBy { get; set; }
    }
}
