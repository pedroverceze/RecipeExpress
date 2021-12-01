using RecipeExpressDomain.Ingredients.Entities;
using RecipeExpressDomain.Ingredients.Repositories;
using System.Threading.Tasks;
using c = RecipeExpress.Data.Context;

namespace RecipeExpress.Data.Repositories.Entity
{
    public class IngredientEntityRepository : BaseRepository<Ingredient>, IIngredientEntityRepository
    {
        public IngredientEntityRepository(c.Context context) : base(context)
        { }

        public async Task InsertIngredient(Ingredient ingredient)
        {
            await _dbSet.AddAsync(ingredient);
            _context.SaveChanges();
        }
    }
}
