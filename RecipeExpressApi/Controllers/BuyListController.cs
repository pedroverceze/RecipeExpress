using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.BuyList.Commands.Requests;
using RecipeExpressDomain.BuyList.Documents.Request;
using RecipeExpressDomain.BuyList.Services;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class BuyListController : ControllerBase
{
    private readonly IMediator _mediatr;
    private readonly ILogger<BuyListController> _logger;
    private readonly IBuyListService _buyListService;

    public BuyListController(IMediator mediator,
                             ILogger<BuyListController> logger,
                             IBuyListService buyListService)
    {
        _logger = logger;
        _mediatr = mediator;
        _buyListService = buyListService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid clientId)
    {
        var result = await _buyListService.GetBuyList(clientId);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateBuyListDto createBuyListDto)
    {
        _logger.LogInformation("Receiving requisition...");

        var command = new CreateBuyListCommand(createBuyListDto);
        var result = await _mediatr.Send(command);

        return CreatedAtAction(nameof(Post), result);
    }
}