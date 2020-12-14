using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoRestApi.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MongoRestApi.DataAccess
{
    public class MongoDbDataAccess : IDataAccess
    {
        private const string dbName = "catalog-of-magic-items";
        private const string collectionName = "games";
        private readonly IMongoCollection<Game> mongoCollection;
        private readonly FilterDefinitionBuilder<Game> filterBuilder = Builders<Game>.Filter;

        private readonly StringObjectIdGenerator idGenerator;

        public MongoDbDataAccess()
        {
            idGenerator = new StringObjectIdGenerator();
            IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(dbName);
            mongoCollection = mongoDatabase.GetCollection<Game>(collectionName);
        }

        public string CreateGame(Game game)
        {          
            mongoCollection.InsertOne(game);
            var id = game.Id;
            return id;
        }

        public Game GetGame(string id)
        {
            var filter = filterBuilder.Eq(gameInDB => gameInDB.Id, id);
            return mongoCollection.Find(filter).SingleOrDefault();
            
        }

        public IEnumerable<Game> GetAllGames()
        {
            return mongoCollection.Find(new BsonDocument()).ToList<Game>();
        }

        public void RemoveGame(string id)
        {
            throw new NotImplementedException();
        }

        
    }
}