using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeExpressDomain.BuyList.Commands.Requests;
using RecipeExpressDomain.BuyList.Documents.Request;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class BuyListController : ControllerBase
{
    private readonly IMediator _mediatr;
    private readonly ILogger<BuyListController> _logger;

    public BuyListController(IMediator mediator, 
                             ILogger<BuyListController> logger)
    {
        _logger = logger;
        _mediatr = mediator;
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