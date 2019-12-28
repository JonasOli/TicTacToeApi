using jogoVelha.Enums;

namespace jogoVelha.models
{
    public class Player
    {
        public PlayerEnum Name { get; set; }

        public Player(PlayerEnum name)
        {
            this.Name = name;
        }
    }
}