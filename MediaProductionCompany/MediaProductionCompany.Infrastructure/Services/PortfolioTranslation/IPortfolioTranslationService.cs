using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.PortfolioTranslation
{
    public interface IPortfolioTranslationService
    {
        List<PortfolioTranslationVM> SearchAndFilter(SearchAndFilterDto dto);
        Task<List<PortfolioTranslationVM>> Index();
        Task<PortfolioTranslationVM> Create(string userId, CreatePortfolioTranslationDto dto);
        Task Delete(string userId, int Id);
        Task<PortfolioTranslationVM> Edit(string userId, UpdatePortfolioTranslationDto dto);
        Task<List<PortfolioTranslationVM>> GetOne(int Id);

    }
}
