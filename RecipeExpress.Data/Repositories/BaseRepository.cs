using Microsoft.EntityFrameworkCore;
using RecipeExpress.Data.Context;

namespace RecipeExpress.Data.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
    }
}
