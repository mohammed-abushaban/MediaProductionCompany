using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Infrastructure.Services.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
   // [Authorize]
    public class CountryController : BaseController
    {


        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        //[Authorize]
        // GET: CountryController
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var Countries = await _countryService.Index();
            return Ok(GetResponse(Countries));
        }

        // GET: CountryController/Details/5
        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var Country = await _countryService.Details(id);
            return Ok(GetResponse(Country));
        }

        // POST: CountryController/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryDto dto)
        {
            var Country = await _countryService.Create(UserId,dto);
            return Ok(GetResponse(Country));

        }

        // Delete: CountryController/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryService.Delete(UserId, id);
            return Ok(GetResponse());
        }
    }
}
