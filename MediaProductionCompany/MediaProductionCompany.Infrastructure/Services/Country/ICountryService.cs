using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Country
{
    public interface ICountryService
    {
        Task<List<CountryVM>> Index();
        Task<CountryDetailsVM> Details(int Id);
        Task<CountryVM> Create(string UserId, CreateCountryDto dto);
        Task Delete(string UserId, int Id);
    }
}
