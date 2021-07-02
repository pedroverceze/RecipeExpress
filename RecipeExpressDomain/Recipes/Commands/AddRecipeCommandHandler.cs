using MediatR;
using RecipeExpressDomain.Configurations.Commands;
using RecipeExpressDomain.Recipes.Commands.Requests;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Commands
{
    public class AddRecipeCommandHandler : IRequestHandler<AddRecipeCommand, RecipeDocument>
    {
        private readonly IRecipeService _recipeService;

        public AddRecipeCommandHandler(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<RecipeDocument> Handle(AddRecipeCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            await _recipeService.EnrollRecipe(command.RecipeDocument);

            return command.RecipeDocument;
        }
    }
}
