using RecipeExpressDomain.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpressDomain.Abstract.Entities
{
    public abstract class Document : IDocument
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
