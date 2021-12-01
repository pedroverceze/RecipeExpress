using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.Ingredients.Commands.Requests;
using RecipeExpressDomain.Ingredients.Documents;
using RecipeExpressDomain.Ingredients.Entities;
using System.Threading.Tasks;

namespace RecipeExpressApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<IngredientController> _logger;

        public IngredientController(IMediator mediator,
                                    ILogger<IngredientController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ingredient req)
        {
            _logger.LogInformation("Recebendo requisição...");

            var command = new AddIngredientCommand(req);
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), req);
        }
    }
}