using Microsoft.EntityFrameworkCore;
using RecipeExpress.Data.Mappings;

namespace RecipeExpress.Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMapper());
            modelBuilder.ApplyConfiguration(new IngredientMapper());
            modelBuilder.ApplyConfiguration(new RecipeMapper());
            modelBuilder.ApplyConfiguration(new ClientRecipeMapper());
        }
    }
}
