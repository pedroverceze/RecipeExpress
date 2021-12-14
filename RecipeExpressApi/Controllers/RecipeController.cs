using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.Recipes.Commands.Requests;
using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Services;
using System;
using System.Threading.Tasks;

namespace RecipeExpressApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipeController(IMediator mediator,
                                ILogger<RecipeController> logger,
                                IRecipeService recipeService)
        {
            _logger = logger;
            _mediator = mediator;
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Recipe req)
        {
            _logger.LogInformation("Receiving requisition...");

            var command = new AddRecipeCommand(req);
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Post), req);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var recipe = await _recipeService.GetRecipe(id);

            return Ok(recipe);
        }
    }
}
