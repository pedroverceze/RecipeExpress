using FluentValidation;
using FluentValidation.Results;
using RecipeExpressDomain.Configurations.Commands;
using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Validations;

namespace RecipeExpressDomain.Recipes.Commands.Requests
{
    public class AddRecipeCommand : Command<Recipe>
    {
        private readonly IValidator<Recipe> _validator;
        private ValidationResult _validationResult;

        public AddRecipeCommand(Recipe recipe)
        {
            _validator = new RecipeDocumentValidator();
            Recipe = recipe;
        }

        public Recipe Recipe { get; private set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(Recipe);
                }
                return _validationResult;
            }
        }
    }
}
