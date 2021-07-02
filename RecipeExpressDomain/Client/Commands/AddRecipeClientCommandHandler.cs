using MediatR;
using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
