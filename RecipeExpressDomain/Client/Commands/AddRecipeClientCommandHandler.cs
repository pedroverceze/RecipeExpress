using MediatR;
using RecipeExpressDomain.Client.Entities;
using RecipeExpressDomain.Client.Services;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Client.Commands.Requests
{
    public class AddRecipeClientCommandHandler : IRequestHandler<AddRecipeClientCommand, ClientRecipe>
    {
        private readonly IClientService _clientService;

        public AddRecipeClientCommandHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<ClientRecipe> Handle(AddRecipeClientCommand command, CancellationToken cancellationToken)
        {
            await _clientService.EnrollRecipe(command.ClientRecipe);

            return command.ClientRecipe;
        }
    }
}
