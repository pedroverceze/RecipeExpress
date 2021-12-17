using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.Client.Commands;
using RecipeExpressDomain.Client.Services;
using System;
using System.Threading.Tasks;
using c = RecipeExpressDomain.Client.Entities;

namespace RecipeExpressApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger,
                                IMediator mediator,
                                IClientService clientService)
        {
            _logger = logger;
            _mediator = mediator;
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(c.Client req)
        {
            _logger.LogInformation("Recebendo requisição...");

            var command = new AddClientCommand(req);
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), req);
        }

        [HttpPost]
        [Route("/addRecipe")]
        public async Task<IActionResult> AddRecipe(Guid recipeId, Guid clientId)
        {
            await _clientService.AddRecipe(recipeId, clientId);

            return CreatedAtAction(nameof(Post), recipeId);
        }
    }
}
