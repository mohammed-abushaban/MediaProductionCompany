using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Infrastructure.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        // GET: UserController
        [HttpGet]

        public async Task<IActionResult> Index(string s)
        {
            var Countries = await _UserService.Index(s);
            return Ok(GetResponse(Countries));
        }

        // GET: UserController/Details/5
        [HttpGet]
        
        public async Task<IActionResult> Details(string id)
        {
            var User = await _UserService.Details(id);
            return Ok(GetResponse(User));
        }

        // PUT: UserController/Update
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDto dto)
        {
            var User = await _UserService.Update(UserId, dto);
            return Ok(GetResponse(User));
        }


        // POST: UserController/Create
        [HttpPost]
        public async Task<IActionResult> Create(RegisterUserDto dto)
        {
            var User = await _UserService.Create(UserId, dto);
            return Ok(GetResponse(User));

        }

        // Delete: UserController/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _UserService.Delete(UserId, id);
            return Ok(GetResponse());
        }
        // GET: UserController/Delete/5
        [HttpGet]

        public async Task<IActionResult> AutoComplete(string s)
        {
            var result = await _UserService.AutoComplete(s);
            return Ok(GetResponse(result));
        }
    }
}
