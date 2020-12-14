using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoRestApi.Entities
{
    public record Game
    {
        [BsonId]
        public Guid Id { get; init; }

        public string Name { get; init; }

        public string Summary { get; init; }
    }
        
}

