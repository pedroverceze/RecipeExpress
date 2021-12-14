using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeExpress.Data.Repositories.Entity;
using RecipeExpressDomain.BuyList.Commands;
using RecipeExpressDomain.BuyList.Commands.Requests;
using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Services;
using RecipeExpressDomain.Client.Commands;
using RecipeExpressDomain.Client.Commands.Requests;
using RecipeExpressDomain.Client.Entities;
using RecipeExpressDomain.Client.Services;
using RecipeExpressDomain.Ingredients.Commands;
using RecipeExpressDomain.Ingredients.Commands.Requests;
using RecipeExpressDomain.Ingredients.Entities;
using RecipeExpressDomain.Ingredients.Repositories;
using RecipeExpressDomain.Ingredients.Services;
using RecipeExpressDomain.Recipes.Commands;
using RecipeExpressDomain.Recipes.Commands.Requests;
using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Services;
using c = RecipeExpressDomain.Client.Entities;

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
            services.AddScoped<IIngredientEntityRepository, IngredientEntityRepository>();

            services.AddScoped<IRequestHandler<AddClientCommand, c.Client>, AddClientCommandHandler>();
            services.AddScoped<IRequestHandler<AddRecipeClientCommand, ClientRecipe>, AddRecipeClientCommandHandler>();
            services.AddScoped<IRequestHandler<AddRecipeCommand, Recipe>, AddRecipeCommandHandler>();
            services.AddScoped<IRequestHandler<CreateBuyListCommand, BuyListDocument>, CreateBuyListCommandHandler>();
            services.AddScoped<IRequestHandler<AddIngredientCommand, Ingredient>, AddIngredientCommandHandler>();
        }
    }
}
