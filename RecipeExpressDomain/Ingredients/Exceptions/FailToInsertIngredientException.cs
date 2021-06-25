using RecipeExpressDomain.Abstract.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Ingredients.Exceptions
{
    public class FailToInsertIngredientException : DomainException
    {
        public FailToInsertIngredientException(string message) : base(message) { }
    }
}
