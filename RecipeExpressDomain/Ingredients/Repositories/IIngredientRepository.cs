using RecipeExpressDomain.Ingredients.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Repositories
{
    public interface IIngredientRepository
    {
        Task<bool> EnrollIngredient(Ingredient ingredient);
    }
}
