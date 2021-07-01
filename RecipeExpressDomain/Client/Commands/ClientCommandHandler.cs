using MediatR;
using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Services;
using RecipeExpressDomain.Configurations.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Client.Commands
{
    public class ClientCommandHandler : IRequestHandler<AddClientCommand, ClientDocument>
    {
        private IClientService _clientService;

        public ClientCommandHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<ClientDocument> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            await _clientService.EnrollClient(request.ClientDocument);

            return request.ClientDocument;
        }
    }
}
