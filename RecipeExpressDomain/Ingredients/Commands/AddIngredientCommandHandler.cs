using MediatR;
using RecipeExpressDomain.Ingredients.Commands.Requests;
using RecipeExpressDomain.Ingredients.Entities;
using RecipeExpressDomain.Ingredients.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Commands
{
    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, Ingredient>
    {
        private readonly IIngredientService _ingredientService;

        public AddIngredientCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<Ingredient> Handle(AddIngredientCommand command, CancellationToken cancellationToken)
        {
            return await _ingredientService.EnrollIngredient(command.Ingredient);
        }
    }
}
