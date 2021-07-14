using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Infrastructure.Services.Portfolio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    public class PortfolioController : BaseController
    {
        private IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            var portfolios = await _portfolioService.Index();
            return Ok(GetResponse(portfolios, "done"));
        }

        // POST: CategoryController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePortfolioDto dto)
        {
            var portfolios = await _portfolioService.Create(dto);
            return Ok(GetResponse(portfolios, "done"));
        }



        // PUT: CategoryController/Edit
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]UpdatePortfolioDto dto)
        {
            var portfolios = await _portfolioService.Edit(dto);
            return Ok(GetResponse(portfolios, "done"));

        }

        // Delete: CategoryController/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _portfolioService.Delete(id);
            return Ok(GetResponse());
        }
    }
}
