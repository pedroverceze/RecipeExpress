using FluentValidation;
using RecipeExpressDomain.Recipes.Documents;

namespace RecipeExpressDomain.Recipes.Validations
{
    public class RecipeDocumentValidator : AbstractValidator<RecipeDocument>
    {
        public RecipeDocumentValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
