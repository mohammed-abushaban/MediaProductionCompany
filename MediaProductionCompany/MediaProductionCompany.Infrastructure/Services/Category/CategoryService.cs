using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.Exceptions;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data;
using MediaProductionCompany.Data.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Category
{
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDbContext _Db;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext db, IMapper mapper)
        {
            _Db = db;
            _mapper = mapper;
        }

        public async Task<List<CategoryVM>> Index()
        {
            return _mapper.Map<List<CategoryVM>>(_Db.Categories.ToList());
        }

        public async Task<CategoryVM> Details(int Id)
        {
            var category = _Db.Categories.SingleOrDefault(x => x.Id == Id);
            if (category == null)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<CategoryVM>(category);
        }
        public async Task<CategoryVM> Create(string userId ,CreateCategoryDto dto)
        {
            var category = _mapper.Map<CategoryDbEntity>(dto);
            category.InsertUserId = userId;
            var result = await _Db.Categories.AddAsync(category);
            await _Db.SaveChangesAsync();
            return _mapper.Map<CategoryVM>(result.Entity);
        }
        public async Task<CategoryVM> Edit(string userId, UpdateCategoryDto dto)
        {
            var category = _Db.Categories.SingleOrDefault(x => x.Id == dto.Id);
            if (category == null)
            {
                throw new NotFoundException();
            }
            _mapper.Map(dto, category);
            category.UpdateUserId = userId;
            await _Db.SaveChangesAsync();
            return _mapper.Map<CategoryVM>(category);
        }

        public async Task Delete(string userId ,int Id)
        {
            var category = _Db.Categories.SingleOrDefault(x => x.Id == Id);
            if (category == null)
            {
                throw new NotFoundException();
            }
            category.DeletedAt = DateTime.Now;
            category.DeleteUserId = userId;
            _Db.Update(category);
            await _Db.SaveChangesAsync();
        }
    }
}
