using MediaProductionCompany.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    public class LanguageController : Controller
    {
        // GET: LanguageController
        public Task<IActionResult> Index()
        {

        }

        // GET: LanguageController/Details/5
        public Task<IActionResult> Details(int id)
        {
        }

        // POST: LanguageController/Create
        [HttpPost]
        public Task<IActionResult> Create(CreateLanguageDto dto)
        {

        }



        // POST: LanguageController/Edit/5
        [HttpPut]
        public Task<IActionResult> Edit(UpdateLanguageDto dto)
        {

        }

        // POST: LanguageController/Delete/5
        [HttpDelete]
        public Task<IActionResult> Delete(int id, IFormCollection collection)
        {

        }
    }
}
