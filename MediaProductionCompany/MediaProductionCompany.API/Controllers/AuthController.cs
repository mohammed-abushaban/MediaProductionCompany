using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Infrastructure.Services.Auth;
using MediaProductionCompany.Infrastructure.Services.PortfolioTranslation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {

        private readonly IAuthService _authService;
        private readonly IPortfolioTranslationService _service;


        public AuthController(IAuthService authService, IPortfolioTranslationService service)
        {
            _authService = authService;
            _service = service;
        }

        [HttpPost]
        public IActionResult TestFilter([FromBody] SearchAndFilterDto dto)
        {
            var result = _service.SearchAndFilter(dto);
            return Ok(GetResponse(result));
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(GetResponse(result));
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegisterUserDto dto)
        {
            var result = await _authService.SignUpAsync(dto);
            return Ok(GetResponse(result));
        }
    }
}
