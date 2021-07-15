using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Infrastructure.Services.PortfolioTranslation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.API.Controllers
{
    public class PortfolioTranslationController : BaseController
    {
        private IPortfolioTranslationService _portfolioTranslationService;

        public PortfolioTranslationController(IPortfolioTranslationService portfolioTranslationService)
        {
            _portfolioTranslationService = portfolioTranslationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoreis = await _portfolioTranslationService.Index();
            return Ok(GetResponse(categoreis));
        }

        [HttpGet]
        public async Task<IActionResult> AllForOne(int Id)
        {
            var categoreis = await _portfolioTranslationService.GetOne(Id);
            return Ok(GetResponse(categoreis));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreatePortfolioTranslationDto dto)
        {
            var portfolioTranslation = await _portfolioTranslationService.Create(UserId, dto);
            return Ok(GetResponse(portfolioTranslation));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromForm]UpdatePortfolioTranslationDto dto)
        {
            var portfolioTranslation = await _portfolioTranslationService.Edit(UserId, dto);
            return Ok(GetResponse(portfolioTranslation));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _portfolioTranslationService.Delete(UserId, Id);
            return Ok(GetResponse());
        }

        [HttpPost]
        public IActionResult TestFilter([FromBody] SearchAndFilterDto dto)
        {
            var result = _portfolioTranslationService.SearchAndFilter(dto);
            return Ok(GetResponse(result));
        }
    }
}
