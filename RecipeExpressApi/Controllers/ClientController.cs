using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.Client.Commands;
using RecipeExpressDomain.Client.Commands.Requests;
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
        private readonly IMediator _mediator;
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger,
                                IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientDocument req)
        {
            _logger.LogInformation("Recebendo requisição...");

            var command = new AddClientCommand(req);
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), req);
        }


        [HttpPatch]
        public async Task<IActionResult> EnrollRecipe(ClientRecipe clientRecipe)
        {
            _logger.LogInformation("Recebendo requisição...");

            var command = new AddRecipeClientCommand(clientRecipe);
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), clientRecipe); ;
        }
    }
}
