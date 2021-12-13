using MediatR;
using RecipeExpressDomain.Configurations.Commands;
using RecipeExpressDomain.Recipes.Commands.Requests;
using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Commands
{
    public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, Recipe>
    {
        private readonly IRecipeService _recipeService;

        public AddRecipeCommandHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<Recipe> Handle(AddRecipeCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            await _recipeService.EnrollRecipe(command.Recipe);

            return command.Recipe;
        }
    }
}
