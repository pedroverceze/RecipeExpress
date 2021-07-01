using FluentValidation;
using FluentValidation.Results;
using RecipeExpressDomain.Client.Documents;
using RecipeExpressDomain.Client.Validations;
using RecipeExpressDomain.Configurations.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Client.Commands
{
    public class AddClientCommand : Command<ClientDocument>
    {
        private readonly IValidator<ClientDocument> _validator;
        private ValidationResult _validationResult;

        public AddClientCommand(ClientDocument client)
        {
            _validator = new ClientDocumentValidator();
            ClientDocument = client;
        }

        public ClientDocument ClientDocument { get; private set; }

        public override ValidationResult ValidationResult
        {
            get
            {
                if (_validationResult is null)
                {
                    _validationResult = _validator.Validate(ClientDocument);
                }
                return _validationResult;
            }
        }
    }
}
