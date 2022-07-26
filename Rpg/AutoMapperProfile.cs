using AutoMapper;
using Rpg.Dto.CharacterDto;
using Rpg.Dto.WeaponDto;
using Rpg.Models;

namespace Rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
        }
    }
}
