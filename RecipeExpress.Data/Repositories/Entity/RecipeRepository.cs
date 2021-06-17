using RecipeExpress.Data.Context;
using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Repositories.Entity
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DataContext context) : base(context)
        { }

        public async Task<bool> EnrollRecipe(Recipe recipe)
        {
            var alreadyExists = Filter(recipe.RecipeId).Any();
            if (alreadyExists)
            {
                _dbSet.Attach(recipe);
            }
            else
            {
                await _dbSet.AddAsync(recipe);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        private IQueryable<Recipe> Filter(Guid recipeId)
            => _dbSet.Where(recipe => recipe.RecipeId == recipeId);
    }
}
