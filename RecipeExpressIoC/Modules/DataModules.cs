using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeExpress.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressIoC.Modules
{
    public class DataModules
    {
        private const string CdbConnectionStringName = "Recipe";
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(GetConnectionString(configuration))
            );

            //services.AddScoped<IInvestmentCardRepository, InvestmentCardRepository>();
            
        }

        private static string GetConnectionString(IConfiguration configuration)
           => configuration.GetConnectionString(CdbConnectionStringName);
    }
}
