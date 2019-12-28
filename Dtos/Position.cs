using System.ComponentModel.DataAnnotations;

namespace jogoVelha.Dtos
{
    public class Position
    {
        [Range(0, 2)]
        public int X { get; set; }
        [Range(0, 2)]
        public int Y { get; set; }
    }
}