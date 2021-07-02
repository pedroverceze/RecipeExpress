using FluentValidation;
using FluentValidation.Results;
using RecipeExpressDomain.BuyList.Documents;
using RecipeExpressDomain.BuyList.Documents.Request;
using RecipeExpressDomain.BuyList.Validations;
using RecipeExpressDomain.Configurations.Commands;

namespace RecipeExpressDomain.BuyList.Commands.Requests
{
    public class CreateBuyListCommand : Command<BuyListDocument>
    {
        private readonly IValidator<CreateBuyListDto> _validator;
        private ValidationResult _validationResult;

        public CreateBuyListCommand(CreateBuyListDto clientID)
        {
            _validator = new BuyListDocumentValidator();
            CreateBuyListDto = clientID;
        }

        public CreateBuyListDto CreateBuyListDto { get; private set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(CreateBuyListDto);
                }
                return _validationResult;
            }
        }
    }
}
