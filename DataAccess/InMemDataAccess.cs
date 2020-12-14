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

        public void CreateGame(Game game)
        {
            gameList.Add(game);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return gameList;
        }

        public Game GetGame(Guid id)
        {
            return gameList.FirstOrDefault(game  => game.Id == id);
        }

        public void RemoveGame(Guid id)
        {
            var gameToRemove = gameList.FirstOrDefault(game => game.Id == id);
            if (gameToRemove != null)
            {
                gameList.Remove(gameToRemove );
            }
        }
    }
}