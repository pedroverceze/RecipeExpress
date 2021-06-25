using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Services;
using System.Threading.Tasks;

namespace RecipeExpressApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipeController> _logger;

        public RecipeController(IRecipeService recipeService, ILogger<RecipeController> logger)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RecipeDocument req)
        {
            _logger.LogInformation("Recebendo requisição...");
            await _recipeService.EnrollRecipe(req);

            return CreatedAtAction(nameof(Post), req);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recipes = await _recipeService.GetRecipes();

            return Ok(recipes);
        }
    }
}
