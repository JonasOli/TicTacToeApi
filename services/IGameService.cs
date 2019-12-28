using jogoVelha.models;

namespace jogoVelha.services
{
    public interface IGameService
    {
        Game Create();
        Game Play(string id, string player, int positionX, int positionY);
    }
}