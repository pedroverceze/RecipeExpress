using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Abstract.Entities
{
    public abstract class EntityBase
    {
        public DateTime CreatedAt { get; set; }
    }
}
