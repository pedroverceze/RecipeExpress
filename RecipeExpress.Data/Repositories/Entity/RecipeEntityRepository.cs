using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Repositories;
using System;
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

        public async Task InsertRecipe(IRecipe recipe)
        {
            await _dbSet.AddAsync((Recipe)recipe);
            _context.SaveChanges();
        }

        private IQueryable<Recipe> Filter(Guid id)
        {
            return _dbSet.Where(r => r.RecipeId == id);
        }
    }
}
