using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.BuyList.Documents.Request;
using RecipeExpressDomain.BuyList.Services;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class BuyListController : ControllerBase
{
    private readonly ILogger<BuyListController> _logger;
    private readonly IBuyListService _buyListService;

    public BuyListController(ILogger<BuyListController> logger,
                             IBuyListService buyListService)
    {
        _logger = logger;
        _buyListService = buyListService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid clientId)
    {
        var result = await _buyListService.GetBuyList(clientId);

        return Ok(result);
    }
}