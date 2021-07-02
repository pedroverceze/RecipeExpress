using MediatR;
using RecipeExpressDomain.BuyList.Commands.Requests;
using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RecipeExpressDomain.BuyList.Commands
{
    public class CreateBuyListCommandHandler : IRequestHandler<CreateBuyListCommand, BuyListDocument>
    {
        private IBuyListService _buyListService;

        public CreateBuyListCommandHandler(IBuyListService buyListService)
        {
            _buyListService = buyListService;
        }

        public async Task<BuyListDocument> Handle(CreateBuyListCommand command, CancellationToken cancellationToken)
        {
            return await _buyListService.RegisterBuyList(command.CreateBuyListDto);
        }
    }
}
