using FluentValidation;
using FluentValidation.Results;
using RecipeExpressDomain.Configurations.Commands;
using RecipeExpressDomain.Ingredients.Entities;
using RecipeExpressDomain.Ingredients.Validations;

namespace RecipeExpressDomain.Ingredients.Commands.Requests
{
    public class AddIngredientCommand : Command<Ingredient>
    {
        private readonly IValidator<Ingredient> _validator;
        private ValidationResult _validationResult;

        public AddIngredientCommand(Ingredient ingredient)
        {
            _validator = new IngredientDocumentValidator();
            Ingredient = ingredient;
        }

        public Ingredient Ingredient { get; private set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(Ingredient);
                }
                return _validationResult;
            }
        }
    }
}
