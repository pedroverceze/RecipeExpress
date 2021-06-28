using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.BuyList.Services;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class BuyListController : ControllerBase
{
    private readonly IBuyListService _buyListService;
    private readonly ILogger<BuyListController> _logger;

    public BuyListController(IBuyListService clientService, ILogger<BuyListController> logger)
    {
        _logger = logger;
        _buyListService = clientService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Guid clientId)
    {
        _logger.LogInformation("Recebendo requisição...");
        await _buyListService.CreateBuyList(clientId);

        return CreatedAtAction(nameof(Post), clientId);
    }
}