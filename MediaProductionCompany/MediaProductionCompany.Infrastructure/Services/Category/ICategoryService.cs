using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Category
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> Index();
        Task<CategoryVM> Details(int Id);

        Task<CategoryVM> Create(string userId, CreateCategoryDto dto);

        Task<CategoryVM> Edit(string userId, UpdateCategoryDto dto);

        Task Delete(string userId, int Id);
    }
}
