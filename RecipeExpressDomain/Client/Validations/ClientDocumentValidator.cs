using FluentValidation;
using RecipeExpressDomain.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Client.Validations
{
    public class ClientDocumentValidator : AbstractValidator<ClientDocument>
    {
        public ClientDocumentValidator()
        {
            RuleFor(c => c.Age)
                .NotEmpty()
                .NotNull()
                .GreaterThan(18);

            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
