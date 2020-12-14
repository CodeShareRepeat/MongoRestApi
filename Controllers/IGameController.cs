using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoRestApi.Entities;

namespace MongoRestApi.Controllers
{
    public interface IGameController
    {
        ActionResult<Game> CreateGame(string name, string summary);

        ActionResult DeleteGame(string id);

        ActionResult<IEnumerable<Game>> GetAllGames();
        
        ActionResult<Game> GetGame(string id);
         
    }


}