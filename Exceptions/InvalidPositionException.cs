using System;
namespace jogoVelha.Exceptions
{
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException() : base("Posição já preenchida")
        {

        }
    }
}