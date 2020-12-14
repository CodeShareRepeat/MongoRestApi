using System.Collections.Generic;
using MongoRestApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoRestApi.DataAccess;

namespace MongoRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase, IGameController
    {

        private readonly ILogger<GameController> _logger;
        private readonly IDataAccess _dataAccess;

        public GameController(ILogger<GameController> logger, IDataAccess dataAccess )
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        [HttpGet("GetGame")]
        public Game GetGame(string id)
        {
            return _dataAccess.GetGame(id);
        }

        [HttpPost("CreateGame")]
        public string CreateGame(string name, string summary)
        {
            return _dataAccess.CreateGame(new Game{ Name = name, Summary = summary});

        }

        [HttpDelete("DeleteGame")]
        public void DeleteGame(string id)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("GetAllGames")]
        public IEnumerable<Game> GetAllGames()
        {
           return _dataAccess.GetAllGames();
        }
    }
}
