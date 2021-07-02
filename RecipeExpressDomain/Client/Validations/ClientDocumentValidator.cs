using FluentValidation;
using RecipeExpressDomain.Client.Documents;

namespace RecipeExpressDomain.Client.Validations
{
    public class ClientDocumentValidator : AbstractValidator<ClientDocument>
    {
        public ClientDocumentValidator()
        {
            RuleFor(c => c.Age)
                .NotEmpty()
                .NotNull()
                .GreaterThan(18);

            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
