using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeExpress.Data.Config;
using RecipeExpress.Data.Context;
using RecipeExpress.Data.Interfaces;
using RecipeExpress.Data.Repositories;
using RecipeExpress.Data.Repositories.Entity;
using RecipeExpress.Data.Repositories.Mongo;
using RecipeExpressDomain.Abstract.Interfaces;
using RecipeExpressDomain.Client.Repositories;
using RecipeExpressDomain.Ingredients.Repositories;
using RecipeExpressDomain.Recipes.Repositories;

namespace RecipeExpressIoC.Modules
{
    public class DataModules
    {
        private const string CdbConnectionStringName = "Recipe";
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var mongoConfig = configuration.GetSection("MongoDbConfig").Get<MongoDbSettings>();

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(GetConnectionString(configuration))
            );

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddSingleton<IMongoDbSettings>(t => mongoConfig);
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IClientMongoRepository, ClientMongoRepository>();
            services.AddScoped<IIngredientMongoRepository, IngredientMongoRepository>();
            services.AddScoped<IRecipeMongoRepository, RecipeMongoRepository>();
        }

        private static string GetConnectionString(IConfiguration configuration)
           => configuration.GetConnectionString(CdbConnectionStringName);
    }
}
