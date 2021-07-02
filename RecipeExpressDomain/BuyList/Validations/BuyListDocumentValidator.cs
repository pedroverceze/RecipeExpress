using FluentValidation;
using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Documents.Request;

namespace RecipeExpressDomain.BuyList.Validations
{
    public class BuyListDocumentValidator : AbstractValidator<CreateBuyListDto>
    {
        public BuyListDocumentValidator()
        {
            RuleFor(b => b.ClientId)
                .NotEmpty()
                .NotNull();
        }
    }
}
