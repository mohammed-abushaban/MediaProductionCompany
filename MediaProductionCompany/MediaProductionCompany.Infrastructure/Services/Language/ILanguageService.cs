using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Language
{
    public interface ILanguageService
    {
        Task<List<LanguageVM>> Index();
        Task<LanguageVM> Create(string UserId, CreateLanguageDto dto);
    }
}
