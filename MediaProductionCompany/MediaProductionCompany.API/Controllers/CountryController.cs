using MediaProductionCompany.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    public class CountryController : Controller
    {
        // GET: CountryController
        public Task<IActionResult> Index()
        {

        }

        // GET: CountryController/Details/5
        public Task<IActionResult> Details(int id)
        {
        }

        // POST: CountryController/Create
        [HttpPost]
        public Task<IActionResult> Create(CreateCountryDto dto)
        {

        }



        // POST: CountryController/Edit/5
        [HttpPut]
        public Task<IActionResult> Edit(UpdateCountryDto dto)
        {

        }

        // POST: CountryController/Delete/5
        [HttpDelete]
        public Task<IActionResult> Delete(int id)
        {

        }
    }
}
