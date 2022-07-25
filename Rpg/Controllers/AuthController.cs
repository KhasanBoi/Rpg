using Microsoft.AspNetCore.Mvc;
using Rpg.Data;
using Rpg.Dto.UserDto;
using Rpg.Models;

namespace Rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto userRegisterDto)
        {
            var response = await _authRepository.Register(
                new User { Name = userRegisterDto.Username}, userRegisterDto.Password    
            );
            if(!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto userLoginDto)
        {
            var response = await _authRepository.Login(
                userLoginDto.Username, userLoginDto.Password   
            );
            if(!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
