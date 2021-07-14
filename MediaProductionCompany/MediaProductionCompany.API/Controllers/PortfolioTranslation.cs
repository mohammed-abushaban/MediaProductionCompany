using MediaProductionCompany.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    public class PortfolioTranslationTranslation : Controller
    {
        // GET: PortfolioTranslationController
        public Task<IActionResult> Index()
        {

        }

        // GET: PortfolioTranslationController/Details/5
        public Task<IActionResult> Details(int id)
        {
        }

        // POST: PortfolioTranslationController/Create
        [HttpPost]
        public Task<IActionResult> Create(CreatePortfolioTranslationDto dto)
        {

        }



        // PUT: PortfolioTranslationController/Edit
        [HttpPut]
        public Task<IActionResult> Edit(UpdatePortfolioTranslationDto dto)
        {

        }

        // Delete: PortfolioTranslationController/Delete/5
        [HttpDelete]
        public Task<IActionResult> Delete(int id)
        {

        }
    }
}
