using FluentValidation;
using RecipeExpressDomain.Ingredients.Documents;

namespace RecipeExpressDomain.Ingredients.Validations
{
    public class IngredientDocumentValidator : AbstractValidator<IngredientDocument>
    {
        public IngredientDocumentValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
