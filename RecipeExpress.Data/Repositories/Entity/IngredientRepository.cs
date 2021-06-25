using Microsoft.EntityFrameworkCore;
using RecipeExpress.Data.Context;
using RecipeExpressDomain.Ingredients.Entities;
using RecipeExpressDomain.Ingredients.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Repositories.Entity
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(DataContext context) : base(context)
        { }

        public async Task<bool> EnrollIngredient(Ingredient ingredient)
        {
            var alreadyExists = Filter(ingredient.IngredientId).Any();
            if (alreadyExists)
            {
                _dbSet.Attach(ingredient);
            }
            else
            {
                await _dbSet.AddAsync(ingredient);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Ingredient> GetClient(Guid ingredientID)
        => await Filter(ingredientID).FirstOrDefaultAsync();

        private IQueryable<Ingredient> Filter(Guid ingredientId)
            => _dbSet.Where(ingredient => ingredient.IngredientId == ingredientId);
    }
}
