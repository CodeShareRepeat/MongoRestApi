using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoRestApi.Entities;
using MongoDB.Bson;

namespace MongoRestApi.DataAccess
{
    public class MongoDbDataAccess : IDataAccess
    {
        private const string dbName = "catalog-of-magic-items";
        private const string collectionName = "games";
        private readonly IMongoCollection<Game> mongoCollection;
        private readonly FilterDefinitionBuilder<Game> filterBuilder = Builders<Game>.Filter;

        public MongoDbDataAccess()
        {
            IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(dbName);
            mongoCollection = mongoDatabase.GetCollection<Game>(collectionName);
        }

        public void CreateGame(Game game)
        {
            mongoCollection.InsertOne(game);
        }

        public Game GetGame(string id)
        {
            var filter = filterBuilder.Eq(gameInDB => gameInDB.Id.ToString(), id);
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