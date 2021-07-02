using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.Recipes.Commands.Requests;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Services;
using System.Threading.Tasks;

namespace RecipeExpressApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IMediator mediator, ILogger<RecipeController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RecipeDocument req)
        {
            _logger.LogInformation("Receiving requisition...");

            var command = new AddRecipeCommand(req);
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), req);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var recipes = await _mediator.GetRecipes();

        //    return Ok(recipes);
        //}
    }
}
