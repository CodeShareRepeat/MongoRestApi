using System;
using System.Collections.Generic;
using MongoRestApi.Entities;

namespace MongoRestApi.Controllers
{
    public interface IGameController
    {
        string CreateGame(string name, string summary);

        void DeleteGame(string id);

        IEnumerable<Game> GetAllGames();
        
        Game GetGame(string id);
         
    }


}