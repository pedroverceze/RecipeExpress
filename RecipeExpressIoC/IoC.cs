using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeExpressIoC.Modules;
using System;

namespace RecipeExpressIoC
{
    public static class IoC
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            DomainModule.Register(services, configuration);
            return services;
        }
    }
}
