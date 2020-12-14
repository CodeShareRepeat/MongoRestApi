using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoRestApi.Entities;

namespace MongoRestApi.Controllers
{
    public interface IGameAsyncController
    {
        Task<ActionResult<Game>> CreateGameAsync(string name, string summary);

        Task<ActionResult> DeleteGameAsync(string id);

        Task<IEnumerable<Game>> GetAllGamesAsync();

        Task<ActionResult<Game>> GetGameAsync(string id);

    }


}