using System.ComponentModel.DataAnnotations;

namespace jogoVelha.Dtos
{
    public class Movement
    {
        [Required]
        public string Player { get; set; }
        [Required]
        public Position Position { get; set; }
    }
}