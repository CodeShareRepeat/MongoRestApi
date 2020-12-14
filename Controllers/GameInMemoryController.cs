using System.Collections.Generic;
using System.Threading.Tasks;
using MongoRestApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoRestApi.DataAccess;

namespace MongoRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameInMemoryController : ControllerBase, IGamesController
    {

        private readonly ILogger<GameInMemoryController> _logger;
        private readonly IDataAccess _dataAccess;

        public GameInMemoryController(ILogger<GameInMemoryController> logger, IDataAccess dataAccess )
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
        public void CreateGame(Game game)
        {
            _dataAccess.CreateGame(game);

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
