using jogoVelha.Enums;

namespace jogoVelha.models
{
    public class Game
    {
        public string Id { get; set; }
        public Player FirstPlayer { get; set; }
        public Player LastPlayed { get; set; }
        public string[,] Table { get; set; } = new string[3, 3];
        public string Status { get; set; } = StatusValue.OnGoingMatch;
        public string Winner { get; set; }

        public Game(string id, Player firstPlayer, Player lastPlayed)
        {
            this.Id = id;
            this.FirstPlayer = firstPlayer;
            this.LastPlayed = lastPlayed;
        }
    }
}