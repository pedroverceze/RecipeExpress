using FluentValidation.Results;

namespace RecipeExpressDomain.Configurations.Commands
{
    public interface ICommand
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
