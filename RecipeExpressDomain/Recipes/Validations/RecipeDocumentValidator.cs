using FluentValidation;
using RecipeExpressDomain.Recipes.Entities;

namespace RecipeExpressDomain.Recipes.Validations
{
    public class RecipeDocumentValidator : AbstractValidator<Recipe>
    {
        public RecipeDocumentValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
