using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Portfolio
{
    public interface IPortfolioService
    {
        Task<List<PortfolioVM>> Index();
        Task<PortfolioVM> Create(string userId, CreatePortfolioDto dto);
        Task<PortfolioVM> Edit(string userId, UpdatePortfolioDto dto);
        Task Delete(string userId, int Id);

    }
}
