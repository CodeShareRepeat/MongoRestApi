using System.Collections.Generic;
using MongoRestApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoRestApi.DataAccess;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MongoRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameAsyncController : ControllerBase, IGameAsyncController
    {
       private readonly ILogger<GameAsyncController> _logger;
        private readonly IDataAccess _dataAccess;

        public GameAsyncController(ILogger<GameAsyncController> logger, IDataAccess dataAccess )
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }

        [HttpPost("CreateGameAsync")]
        public async Task<ActionResult<Game>> CreateGameAsync(string name, string summary)
        {
            var createdId = await _dataAccess.CreateGameAsync(new Game{ Name = name, Summary = summary});
            
            return CreatedAtAction(nameof(GetGameAsync), new {id = createdId}, new Game{ Id = createdId, Name = name, Summary = summary});
        }

        [HttpDelete("DeleteGameAsync")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteGameAsync(string id)
        {
           var existingItem = await _dataAccess.GetGameAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            await _dataAccess.RemoveGameAsync(id);

            return NoContent();
        }

        [HttpGet("GetAllGamesAsync")]
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _dataAccess.GetAllGamesAsync();
        }

        [HttpGet("GetGameAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Game>> GetGameAsync(string id)
        { 
            var gameFound = await _dataAccess.GetGameAsync(id);

            if (gameFound == null)
                return NotFound();
            
            return gameFound;

        }
    }
}
