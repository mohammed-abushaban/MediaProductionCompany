using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: PortfolioController
        public Task<IActionResult> Index()
        {

        }

        // GET: PortfolioController/Details/5
        public Task<IActionResult> Details(int id)
        {
        }

        // POST: PortfolioController/Create
        [HttpPost]
        public Task<IActionResult> Create(CreatePortfolioDto dto)
        {

        }



        // PUT: PortfolioController/Edit
        [HttpPut]
        public Task<IActionResult> Edit(UpdatePortfolioDto dto)
        {

        }

        // Delete: PortfolioController/Delete/5
        [HttpDelete]
        public Task<IActionResult> Delete(int id)
        {

        }
    }
}
