using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c = RecipeExpress.Data.Context;

namespace RecipeExpress.Data.Repositories.Entity
{
    public class RecipeEntityRepository : BaseRepository<Recipe>, IRecipeEntityRepository
    {
        public RecipeEntityRepository(c.Context context) : base(context)
        { }

        public async Task<Recipe> GetRecipe(Guid id)
        {
            return Filter(id)
                   .FirstOrDefault();
        }

        public Task<List<Recipe>> GetRecipes()
        {
            throw new System.NotImplementedException();
        }

        public async Task InsertRecipe(Recipe recipe)
        {
            await _dbSet.AddAsync(recipe);
        }

        private IQueryable<Recipe> Filter(Guid id)
        {
            return _dbSet.Where(r => r.RecipeId == id);
        }
    }
}
