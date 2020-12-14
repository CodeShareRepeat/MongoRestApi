
using System;
using System.Collections.Generic;
using MongoRestApi.Entities;

namespace MongoRestApi.DataAccess
{
     

    public interface IDataAccess
    {

        string CreateGame(Game game);
        Game GetGame(string id);
        IEnumerable<Game> GetAllGames();
        void RemoveGame(string id);
        
    }
}