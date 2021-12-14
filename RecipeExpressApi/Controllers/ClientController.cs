using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.Client.Commands;
using RecipeExpressDomain.Client.Commands.Requests;
using RecipeExpressDomain.Client.Entities;
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

        public ClientController(ILogger<ClientController> logger,
                                IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(c.Client req)
        {
            _logger.LogInformation("Recebendo requisição...");

            var command = new AddClientCommand(req);
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), req);
        }

        [HttpPost("Recipe")]
        public async Task<IActionResult> EnrollRecipe(ClientRecipe clientRecipe)
        {
            _logger.LogInformation("Recebendo requisição...");

            var command = new AddRecipeClientCommand(clientRecipe);
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), clientRecipe); ;
        }
    }
}
