using AutoMapper;
using jogoVelha.Dtos;
using jogoVelha.Enums;
using jogoVelha.models;

namespace jogoVelha.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(a => a.FirstPlayer, b => b.MapFrom(c => c.FirstPlayer.Name == 0 ? "x" : "o"));
            CreateMap<GameDto, Game>()
                .ForMember(a => a.FirstPlayer, b => b.MapFrom(c => c.FirstPlayer == "x" ? new Player(PlayerEnum.PLAYER_X) : new Player(PlayerEnum.PLAYER_O)));
        }
    }
}