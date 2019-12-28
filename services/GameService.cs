using System;
using jogoVelha.Enums;
using jogoVelha.Exceptions;
using jogoVelha.models;
using jogoVelha.Repositories;

namespace jogoVelha.services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game Create()
        {
            var value = Enum.GetValues(typeof(PlayerEnum));
            var randomPlayer = (PlayerEnum)value.GetValue(new Random().Next(value.Length));
            var newPlayer = new Player(randomPlayer);
            var game = new Game(Guid.NewGuid().ToString(), newPlayer, null);

            _gameRepository.UpdateGame(game);

            return game;
        }

        public Game Play(string id, string playerName, int positionX, int positionY)
        {
            var game = _gameRepository.GetGame(id);
            var playerEnum = playerName == "x" ? PlayerEnum.PLAYER_X : PlayerEnum.PLAYER_O;

            if (game.Status == StatusValue.FinishedMatch)
            {
                throw new MatchFinishedException();
            }

            if (game.LastPlayed == null && game.FirstPlayer.Name != playerEnum)
            {
                throw new InvalidPlayerException();
            }

            if (game.LastPlayed != null && game.LastPlayed.Name == playerEnum)
            {
                throw new InvalidPlayerException();
            }

            if (game.Table[positionX, positionY] != null)
            {
                throw new InvalidPositionException();
            }

            game.Table[positionX, positionY] = playerName;
            game.LastPlayed = new Player(playerEnum);

            CheckStatus(game, playerName);

            _gameRepository.UpdateGame(game);

            return game;
        }

        private void CheckStatus(Game game, string playerName)
        {
            var status = CheckWin(game.Table);

            if (status == 1)
            {
                game.Status = StatusValue.FinishedMatch;
                game.Winner = playerName;
            }
            else if (status == -1)
            {
                game.Status = StatusValue.FinishedMatch;
                game.Winner = "Draw";
            }
        }

        private int CheckWin(string[,] arr)
        {
            // Winning Condition For First Row   
            if (arr[0, 0] == arr[0, 1] && arr[0, 1] == arr[0, 2] && arr[0, 0] != null && arr[0, 1] != null && arr[0, 2] != null)
            {
                return 1;
            }

            // Winning Condition For Second Row   
            else if (arr[1, 0] == arr[1, 1] && arr[1, 1] == arr[1, 2] && arr[1, 0] != null && arr[1, 1] != null && arr[1, 2] != null)
            {
                return 1;
            }

            // Winning Condition For Third Row   
            else if (arr[2, 0] == arr[2, 1] && arr[2, 1] == arr[2, 2] && arr[2, 0] != null && arr[2, 1] != null && arr[2, 2] != null)
            {
                return 1;
            }

            // Winning Condition For First Column
            else if (arr[0, 0] == arr[1, 0] && arr[1, 0] == arr[2, 0] && arr[0, 0] != null && arr[1, 0] != null && arr[2, 0] != null)
            {
                return 1;
            }

            // Winning Condition For Second Column  
            else if (arr[0, 1] == arr[1, 1] && arr[1, 1] == arr[2, 1] && arr[0, 1] != null && arr[1, 1] != null && arr[2, 1] != null)
            {
                return 1;
            }

            // Winning Condition For Third Column  
            else if (arr[0, 2] == arr[1, 2] && arr[1, 2] == arr[2, 2] && arr[0, 2] != null && arr[1, 2] != null && arr[2, 2] != null)
            {
                return 1;
            }

            #region Diagonal Winning Condition

            else if (arr[0, 0] == arr[1, 1] && arr[1, 1] == arr[2, 2] && arr[0, 0] != null && arr[1, 1] != null && arr[2, 2] != null)
            {
                return 1;
            }
            else if (arr[0, 2] == arr[1, 1] && arr[1, 1] == arr[2, 0] && arr[0, 2] != null && arr[1, 1] != null && arr[2, 0] != null)
            {
                return 1;
            }

            #endregion

            // If all the cells or values filled with X or O then any player has won the match  
            else if (
                arr[0, 0] != null &&
                arr[0, 1] != null &&
                arr[0, 2] != null &&
                arr[1, 0] != null &&
                arr[1, 1] != null &&
                arr[1, 2] != null &&
                arr[2, 0] != null &&
                arr[2, 1] != null &&
                arr[2, 2] != null
            )
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}