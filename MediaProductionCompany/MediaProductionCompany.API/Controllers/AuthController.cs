using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Infrastructure.Services.Auth;
using MediaProductionCompany.Infrastructure.Services.PortfolioTranslation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(GetResponse(result));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegisterUserDto dto)
        {
            var result = await _authService.SignUpAsync(dto);
            return Ok(GetResponse(result));
        }
    }
}
