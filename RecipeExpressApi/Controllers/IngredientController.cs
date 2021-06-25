using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.Ingredients.Documents;
using RecipeExpressDomain.Ingredients.Services;
using System.Threading.Tasks;

namespace RecipeExpressApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<IngredientController> _logger;

        public IngredientController(IIngredientService ingredientService, ILogger<IngredientController> logger)
        {
            _logger = logger;
            _ingredientService = ingredientService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IngredientDocument req)
        {
            _logger.LogInformation("Recebendo requisição...");
            await _ingredientService.EnrollIngredient(req);

            return CreatedAtAction(nameof(Post), req);
        }
    }
}