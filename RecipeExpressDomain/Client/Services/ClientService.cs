using RecipeExpressDomain.Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Client.Entities;

namespace RecipeExpressDomain.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task EnrollClient(c.Client client)
        {
            if(!await _clientRepository.EnrollClient(client))
            {
                throw new Exception();
            }
        }
    }
}
