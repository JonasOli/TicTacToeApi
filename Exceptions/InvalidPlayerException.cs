using System;
namespace jogoVelha.Exceptions
{
    public class InvalidPlayerException : Exception
    {
        public InvalidPlayerException() : base("Não é turno do jogador") { }
    }
}