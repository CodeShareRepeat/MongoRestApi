using System.Collections.Generic;
using MongoRestApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoRestApi.DataAccess;

namespace MongoRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameAsyncController : ControllerBase
    {
       private readonly ILogger<GameAsyncController> _logger;
        private readonly IDataAccess _dataAccess;

        public GameAsyncController(ILogger<GameAsyncController> logger, IDataAccess dataAccess )
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        [HttpGet("GetGameAsync")]
        public Game GetGameAsync(string id)
        {
            return _dataAccess.GetGame(id);
        }

        [HttpPost("CreateGameAsync")]
        public string CreateGameAsync(string name, string summary)
        {
            return _dataAccess.CreateGame(new Game{ Name = name, Summary = summary});

        }

        [HttpDelete("DeleteGameAsync")]
        public void DeleteGameAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("GetAllGames")]
        public IEnumerable<Game> GetAllGamesAsync()
        {
           return _dataAccess.GetAllGames();
        }
    }
}
