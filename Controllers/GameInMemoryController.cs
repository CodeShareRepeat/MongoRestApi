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
    public class GameInMemoryController : ControllerBase
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
            return new Game();
        }

        [HttpPost("CreateGame")]
        public void CreateGame(Game game)
        {

        }

        
        
    }
}
