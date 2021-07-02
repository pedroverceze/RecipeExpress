using FluentValidation;
using FluentValidation.Results;
using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Validations;
using RecipeExpressDomain.Configurations.Commands;

namespace RecipeExpressDomain.Client.Commands.Requests
{
    public class AddRecipeClientCommand : Command<ClientRecipe>
    {
        private readonly IValidator<ClientRecipe> _validator;
        private ValidationResult _validationResult;

        public AddRecipeClientCommand(ClientRecipe client)
        {
            _validator = new ClientRecipeValidator();
            ClientRecipe = client;
        }

        public ClientRecipe ClientRecipe { get; private set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(ClientRecipe);
                }
                return _validationResult;
            }
        }
    }
}
