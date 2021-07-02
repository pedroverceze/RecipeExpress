using FluentValidation;
using FluentValidation.Results;
using RecipeExpressDomain.Configurations.Commands;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Validations;

namespace RecipeExpressDomain.Recipes.Commands.Requests
{
    public class AddRecipeCommand : Command<RecipeDocument>
    {
        private readonly IValidator<RecipeDocument> _validator;
        private ValidationResult _validationResult;

        public AddRecipeCommand(RecipeDocument client)
        {
            _validator = new RecipeDocumentValidator();
            RecipeDocument = client;
        }

        public RecipeDocument RecipeDocument { get; private set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(RecipeDocument);
                }
                return _validationResult;
            }
        }
    }
}
