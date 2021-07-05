using FluentValidation;
using FluentValidation.Results;
using RecipeExpressDomain.Configurations.Commands;
using RecipeExpressDomain.Ingredients.Documents;
using RecipeExpressDomain.Ingredients.Validations;

namespace RecipeExpressDomain.Ingredients.Commands.Requests
{
    public class AddIngredientCommand : Command<IngredientDocument>
    {
        private readonly IValidator<IngredientDocument> _validator;
        private ValidationResult _validationResult;

        public AddIngredientCommand(IngredientDocument ingredient)
        {
            _validator = new IngredientDocumentValidator();
            IngredientDocument = ingredient;
        }

        public IngredientDocument IngredientDocument { get; private set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(IngredientDocument);
                }
                return _validationResult;
            }
        }
    }
}
