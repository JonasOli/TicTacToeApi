using jogoVelha.models;

namespace jogoVelha.Repositories
{
    public interface IGameRepository
    {
        void UpdateGame(Game game);
        Game GetGame(string id);
    }
}