using RecipeExpressDomain.Client.Documents;
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
        private readonly IClientMongoRepository _clientMongoRepository;

        public ClientService(IClientRepository clientRepository,
                             IClientMongoRepository clientMongoRepository)
        {
            _clientRepository = clientRepository;
            _clientMongoRepository = clientMongoRepository;
        }

        public async Task EnrollClient(c.Client client)
        {
            if(!await _clientRepository.EnrollClient(client))
            {
                throw new Exception();
            }

            var doc = new ClientDocument
            {
                Age = client.Age,
                CreatedAt = DateTime.Now,
                Genre = client.Genre,
                Name = client.Name,
                Id = client.ClientId
            };

            await _clientMongoRepository.InsertClient(doc);
        }
    }
}
