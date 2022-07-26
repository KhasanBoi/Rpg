using Rpg.Dto.CharacterDto;
using Rpg.Dto.WeaponDto;
using Rpg.Models;

namespace Rpg.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}
