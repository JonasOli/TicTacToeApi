using System;
namespace jogoVelha.Exceptions
{
    public class MatchFinishedException : Exception
    {
        public MatchFinishedException() : base("Partida já encerrada.")
        {

        }
    }
}