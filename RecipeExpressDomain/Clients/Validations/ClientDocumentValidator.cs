using FluentValidation;
using c = RecipeExpressDomain.Clients.Entities;


namespace RecipeExpressDomain.Client.Validations
{
    public class ClientDocumentValidator : AbstractValidator<c.Client>
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
