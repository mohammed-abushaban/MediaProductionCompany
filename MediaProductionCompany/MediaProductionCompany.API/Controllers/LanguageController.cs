using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Infrastructure.Services.Language;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
   //[Authorize("Admin")]
    public class LanguageController : BaseController
    {

        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // GET: LanguageController
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            var result = await _languageService.Index();
            return Ok(GetResponse(result));
        }


        // POST: LanguageController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateLanguageDto dto)
        {
            var result = await _languageService.Create(UserId, dto);
            return Ok(GetResponse(result));

        }

    }
}
