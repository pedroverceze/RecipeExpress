﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeExpressDomain.BuyList.Services;
using RecipeExpressDomain.Client.Commands;
using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Services;
using RecipeExpressDomain.Ingredients.Services;
using RecipeExpressDomain.Recipes.Services;

namespace RecipeExpressIoC.Modules
{
    public static class DomainModule
    {
        public static void Register(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IBuyListService, BuyListService>();

            services.AddScoped<IRequestHandler<AddClientCommand, ClientDocument>, ClientCommandHandler>();
        }
    }
}
