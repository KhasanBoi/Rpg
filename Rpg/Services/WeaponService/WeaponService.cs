using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rpg.Data;
using Rpg.Dto.CharacterDto;
using Rpg.Dto.WeaponDto;
using Rpg.Models;
using System.Security.Claims;

namespace Rpg.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WeaponService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            var response = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character character = await _dbContext.Characters
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
                    c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                
                if(character == null)
                {
                    response.Status = false;
                    response.Message = "Character Not Found";
                    return response;
                }

                Weapon weapon = new Weapon
                {
                    Name = newWeapon.Name,
                    Character = character,
                    Damage = newWeapon.Damage
                };

                _dbContext.Weapons.Add(weapon);
                await _dbContext.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
