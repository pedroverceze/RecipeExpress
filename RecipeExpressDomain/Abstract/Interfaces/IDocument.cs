using MongoDB.Bson.Serialization.Attributes;
using System;

namespace RecipeExpressDomain.Abstract.Interfaces
{
    public interface IDocument
    {
        [BsonId]
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
