using Microsoft.EntityFrameworkCore;
using c = RecipeExpress.Data.Context;

namespace RecipeExpress.Data.Repositories.Entity
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly c.Context _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(c.Context context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
    }

}
