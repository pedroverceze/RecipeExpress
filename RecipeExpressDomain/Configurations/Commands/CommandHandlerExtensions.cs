using FluentValidation;

namespace RecipeExpressDomain.Configurations.Commands
{
    public static class CommandHandlerExtensions
    {
        public static void Validate(this ICommand commandRequest)
        {
            if (commandRequest is null)
            {
                throw new ValidationException($"The command \"{nameof(ICommand)}\" could not be null.");
            }

            if (commandRequest.IsValid)
            {
                return;
            }

            throw new ValidationException(commandRequest.ValidationResult.Errors);
        }
    }
}
