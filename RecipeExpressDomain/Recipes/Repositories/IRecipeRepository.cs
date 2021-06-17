using RecipeExpressDomain.Recipes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Repositories
{
    public interface IRecipeRepository
    {
        Task<bool> EnrollRecipe(Recipe recipe);
    }
}
