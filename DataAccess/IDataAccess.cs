
using System;
using System.Collections.Generic;
using MongoRestApi.Entities;

namespace MongoRestApi.DataAccess
{
     

    public interface IDataAccess
    {

        void CreateGame(Game game);
        Game GetGame(Guid id);
        IEnumerable<Game> GetAllGames();
        void RemoveGame(Guid id);
        
    }
}