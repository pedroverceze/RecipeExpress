using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeExpress.Data.Config;
using RecipeExpress.Data.Context;
using RecipeExpress.Data.Interfaces;
using RecipeExpress.Data.Repositories.Entity;
using RecipeExpress.Data.Repositories.Mongo;
using RecipeExpressDomain.Abstract.Interfaces;
using RecipeExpressDomain.BuyList.Repositories;
using RecipeExpressDomain.Client.Repositories;
using RecipeExpressDomain.Ingredients.Repositories;
using RecipeExpressDomain.Recipes.Repositories;

namespace RecipeExpressIoC.Modules
{
    public class DataModules
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var mongoConfig = configuration.GetSection("MongoDbConfig").Get<MongoDbSettings>();
            var connectionString = configuration.GetConnectionString("Recipe");

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddSingleton<IMongoDbSettings>(t => mongoConfig);
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IBuyListRepository, BuyListMongoRepository>();
            services.AddScoped<IClientEntityRepository, ClientEntityRepository>();
            services.AddScoped<IRecipeEntityRepository, RecipeEntityRepository>();
            services.AddScoped<IIngredientEntityRepository, IngredientEntityRepository>();
        }
    }
}
