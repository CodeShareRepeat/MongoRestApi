using System.Collections.Generic;
using System.Threading.Tasks;
using MongoRestApi.Entities;
namespace MongoRestApi.DataAccess
{
    public interface IDataAccess
    {
        string CreateGame(Game game);

        Task<string> CreateGameAsync(Game game);
        
        Game GetGame(string id);

        Task<Game> GetGameAsync(string id);
        
        IEnumerable<Game> GetAllGames();

        Task<IEnumerable<Game>> GetAllGamesAsync();
        
        void RemoveGame(string id);

        Task RemoveGameAsync(string id);
        
    }
}