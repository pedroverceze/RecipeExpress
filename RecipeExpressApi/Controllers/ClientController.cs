using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Services;
using System;
using System.Threading.Tasks;

namespace RecipeExpressApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientService clientService, ILogger<ClientController> logger)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientDocument req)
        {
            _logger.LogInformation("Recebendo requisição...");
            await _clientService.EnrollClient(req);

            return CreatedAtAction(nameof(Post), req);
        }


        [HttpPatch]
        public async Task<IActionResult> EnrollRecipe(Guid clientId, Guid recipeId)
        {
            _logger.LogInformation("Recebendo requisição...");
            await _clientService.EnrollRecipe(clientId, recipeId);

            return CreatedAtAction(nameof(Post), clientId);
        }
    }
}
