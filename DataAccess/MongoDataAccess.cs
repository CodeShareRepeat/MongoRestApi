using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoRestApi.Entities;

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
            throw new NotImplementedException();
        }

        public Game GetGame(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public void RemoveGame(Guid id)
        {
            throw new NotImplementedException();
        }

        
    }
}