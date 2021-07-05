using MediatR;
using RecipeExpressDomain.Ingredients.Commands.Requests;
using RecipeExpressDomain.Ingredients.Documents;
using RecipeExpressDomain.Ingredients.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Commands
{
    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, IngredientDocument>
    {
        private readonly IIngredientService _ingredientService;

        public AddIngredientCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<IngredientDocument> Handle(AddIngredientCommand command, CancellationToken cancellationToken)
        {
            return await _ingredientService.EnrollIngredient(command.IngredientDocument);
        }
    }
}
