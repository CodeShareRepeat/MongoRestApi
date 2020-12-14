using System;
using System.Collections.Generic;
using MongoRestApi.Entities;

namespace MongoRestApi.Controllers
{
    public interface IGamesController
    {
        void CreateGame(Game game);

        void DeleteGame(string id);

        IEnumerable<Game> GetAllGames();
        
        Game GetGame(string id);
         
    }


}