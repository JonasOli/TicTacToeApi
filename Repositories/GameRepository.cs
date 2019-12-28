using System.IO;
using jogoVelha.Exceptions;
using jogoVelha.models;
using Newtonsoft.Json;

namespace jogoVelha.Repositories
{
    public class GameRepository : IGameRepository
    {
        public Game GetGame(string id)
        {
            try
            {
                var path = Directory.GetCurrentDirectory();
                using (StreamReader r = new StreamReader($@"{path}/saves/{id}.json"))
                {
                    string json = r.ReadToEnd();
                    Game game = JsonConvert.DeserializeObject<Game>(json);

                    return game;
                }
            }
            catch (FileNotFoundException)
            {
                throw new InvalidMatchException();
            }
        }

        public void UpdateGame(Game game)
        {
            var path = Directory.GetCurrentDirectory();

            using (StreamWriter file = File.CreateText($@"{path}/saves/{game.Id}.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                // serialize object directly into file stream
                serializer.Serialize(file, game);
            }
        }
    }
}