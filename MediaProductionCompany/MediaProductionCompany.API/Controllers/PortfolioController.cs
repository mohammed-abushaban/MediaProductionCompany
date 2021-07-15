using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Infrastructure.Services.Portfolio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    [Authorize("Admin")]
    public class PortfolioController : BaseController
    {
        private IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        // GET: portfolioController
        public async Task<IActionResult> Index()
        {
            var portfolios = await _portfolioService.Index();
            return Ok(GetResponse(portfolios, "done"));
        }
       
        // POST: portfolioController/Create
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePortfolioDto dto)
        {
            var portfolio = await _portfolioService.Create(UserId, dto);
            return Ok(GetResponse(portfolio, "done"));
        }



        // PUT: portfolioController/Edit
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdatePortfolioDto dto)
        {
            var portfolio = await _portfolioService.Edit(UserId, dto);
            return Ok(GetResponse(portfolio, "done"));

        }

        // Delete: portfolioController/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _portfolioService.Delete(UserId, id);
            return Ok(GetResponse());
        }
    }
}
