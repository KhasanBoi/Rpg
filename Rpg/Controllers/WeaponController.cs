using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rpg.Dto.CharacterDto;
using Rpg.Dto.WeaponDto;
using Rpg.Models;
using Rpg.Services.WeaponService;

namespace Rpg.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;
        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto weaponDto)
        {
            return Ok(await _weaponService.AddWeapon(weaponDto));
        }
    }
}
