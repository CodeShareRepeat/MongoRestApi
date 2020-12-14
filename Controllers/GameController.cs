using System.Collections.Generic;
using MongoRestApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoRestApi.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Authorize(Roles = "admins")]
        public ActionResult<Game> GetGame(string id)
        {
            var gameToFind = _dataAccess.GetGame(id);

            if (gameToFind == null)
                return NotFound();
            
            return Ok(gameToFind);

        }

        [HttpPost("CreateGame")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public ActionResult<Game> CreateGame(string name, string summary)
        {
            var createdId = _dataAccess.CreateGame(new Game{ Name = name, Summary = summary});
            
            return CreatedAtAction(nameof(GetGame), new {id = createdId}, new Game{ Id = createdId, Name = name, Summary = summary});
        }
       

      
        [HttpDelete("DeleteGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public ActionResult DeleteGame(string id)
        {
            var gameToDelete = _dataAccess.GetGame(id);

            if (gameToDelete == null)
                return NotFound();

           _dataAccess.RemoveGame(id);
           
           return Ok();
        }

        [HttpGet("GetAllGames")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
           return Ok(_dataAccess.GetAllGames());
        }
    }
}
