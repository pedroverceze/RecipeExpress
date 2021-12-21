using MediatR;
using RecipeExpressDomain.Client.Services;
using RecipeExpressDomain.Configurations.Commands;
using System.Threading;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Clients.Entities;

namespace RecipeExpressDomain.Client.Commands
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, c.Client>
    {
        private IClientService _clientService;

        public AddClientCommandHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<c.Client> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            await _clientService.EnrollClient(request.Client);

            return request.Client;
        }
    }
}
