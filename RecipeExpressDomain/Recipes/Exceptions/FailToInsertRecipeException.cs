using RecipeExpressDomain.Abstract.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Recipes.Exceptions
{
    public class FailToInsertRecipeException : DomainException
    {
        public FailToInsertRecipeException(string message) : base(message)
        { }
    }
}
