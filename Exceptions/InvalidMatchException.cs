using System;

namespace jogoVelha.Exceptions
{
    public class InvalidMatchException : Exception
    {
        public InvalidMatchException() : base("Partida não encontrada")
        {

        }
    }
}