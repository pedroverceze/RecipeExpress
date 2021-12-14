﻿using RecipeExpressDomain.Abstract.Entities;
using RecipeExpressDomain.Abstract.Enums;
using RecipeExpressDomain.Client.Entities;
using System;
using System.Collections.Generic;

namespace RecipeExpressDomain.Recipes.Entities
{
    public class Recipe : EntityBase
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; }
        public Difficult Dificult { get; set; }
        public string PrepareMode { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<ClientRecipe> ClientRecipes { get; set; } = new List<ClientRecipe>();
    }
}
