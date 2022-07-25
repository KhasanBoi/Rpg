using AutoMapper;
using Rpg.Dto.CharacterDto;
using Rpg.Models;

namespace Rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
