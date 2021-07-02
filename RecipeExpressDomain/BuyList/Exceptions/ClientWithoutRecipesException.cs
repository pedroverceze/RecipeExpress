using RecipeExpressDomain.Abstract.Exceptions;

namespace RecipeExpressDomain.BuyList.Exceptions
{
    public class ClientWithoutRecipesException : DomainException
    {
        public ClientWithoutRecipesException(string msg) : base(msg)
        { }
    }
}
