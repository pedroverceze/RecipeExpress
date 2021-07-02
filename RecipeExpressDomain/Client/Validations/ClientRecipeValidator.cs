using FluentValidation;
using RecipeExpressDomain.Client.Documents;

namespace RecipeExpressDomain.Client.Validations
{
    public class ClientRecipeValidator : AbstractValidator<ClientRecipe>
    {
        public ClientRecipeValidator()
        {
            RuleFor(c => c.ClientId)
               .NotEmpty()
               .NotNull();

            RuleFor(c => c.RecipeId)
               .NotEmpty()
               .NotNull();
        }
    }
}
