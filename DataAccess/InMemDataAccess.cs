using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoRestApi.Entities;



namespace MongoRestApi.DataAccess
{
    public class InMemDataAccess : IDataAccess
    {
        private readonly List<Game> gameList= new List<Game>
            {
                new Game{  Name = "Command and Conquer", Summary = "2x wow!" },
                new Game {  Name = "Diablo 2", Summary = "wow!" }
            };

        public string CreateGame(Game game)
        {
            
            gameList.Add(new Game{});
            return "123";
        }

        public Task<string> CreateGameAsync(Game game)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return gameList;
        }

        public Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            throw new NotImplementedException();
        }

        public Game GetGame(string id)
        {
            return gameList.FirstOrDefault(game  => game.Id.ToString() == id);
        }

        public Task<Game> GetGameAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveGame(string id)
        {
            var gameToRemove = gameList.FirstOrDefault(game => game.Id.ToString() == id);
            
            if (gameToRemove != null)
            {
                gameList.Remove(gameToRemove );
            }
        }

        public Task RemoveGameAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}