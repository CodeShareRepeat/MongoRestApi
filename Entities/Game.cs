using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MongoRestApi.Entities
{
    public record Game
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; init; }

        public string Name { get; init; }

        public string Summary { get; init; }
    }
        
}

