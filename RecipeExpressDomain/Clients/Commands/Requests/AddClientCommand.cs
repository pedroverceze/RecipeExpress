using FluentValidation;
using FluentValidation.Results;
using RecipeExpressDomain.Client.Validations;
using RecipeExpressDomain.Configurations.Commands;
using c = RecipeExpressDomain.Clients.Entities;


namespace RecipeExpressDomain.Client.Commands
{
    public class AddClientCommand : Command<c.Client>
    {
        private readonly IValidator<c.Client> _validator;
        private ValidationResult _validationResult;

        public AddClientCommand(c.Client client)
        {
            _validator = new ClientDocumentValidator();
            Client = client;
        }

        public c.Client Client { get; private set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(Client);
                }
                return _validationResult;
            }
        }
    }
}
