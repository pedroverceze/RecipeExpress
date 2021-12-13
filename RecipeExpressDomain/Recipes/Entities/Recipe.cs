using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Abstract.Enums;
using System;

namespace RecipeExpressDomain.Recipes.Entities
{
    public class Recipe : EntityBase
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
        public Difficult Dificult { get; set; }
        public string PrepareMode { get; set; }
        public string CreatedBy { get; set; }
    }
}
