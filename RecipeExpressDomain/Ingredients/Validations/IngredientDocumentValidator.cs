using FluentValidation;
using RecipeExpressDomain.Ingredients.Entities;

namespace RecipeExpressDomain.Ingredients.Validations
{
    public class IngredientDocumentValidator : AbstractValidator<Ingredient>
    {
        public IngredientDocumentValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
