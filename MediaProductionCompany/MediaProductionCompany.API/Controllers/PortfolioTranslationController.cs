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
            return Ok(GetResponse(categoreis, "done"));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreatePortfolioTranslationDto dto)
        {
            var portfolioTranslation = await _portfolioTranslationService.Create(UserId, dto);
            return Ok(GetResponse(portfolioTranslation, "done"));
        }
    }
}
