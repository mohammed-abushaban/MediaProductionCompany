using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.Exceptions;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data;
using MediaProductionCompany.Data.DbEntity;
using MediaProductionCompany.Infrastructure.Services.File;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.PortfolioTranslation
{
    public class PortfolioTranslationService : IPortfolioTranslationService
    {


        private readonly ApplicationDbContext _Db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public PortfolioTranslationService(ApplicationDbContext db, IMapper mapper, IFileService fileService)
        {
            _Db = db;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<List<PortfolioTranslationVM>> Index()
        {
            return _mapper.Map<List<PortfolioTranslationVM>>(_Db.PortoFolioTranslations.Include(x => x.Language).Include(x => x.Category).ToList());
        }

        public async Task<List<PortfolioTranslationVM>> GetOne(int Id)
        {
            return _mapper.Map<List<PortfolioTranslationVM>>(_Db.PortoFolioTranslations.Include(x => x.Language).Include(x => x.Category).Where(x => x.PortoFolioId == 1).ToList());
        }

        public async Task<PortfolioTranslationVM> Create(string userId ,CreatePortfolioTranslationDto dto)
        {
            var portfolioTranslation = _mapper.Map<PortfolioTranslationDbEntity>(dto);
            portfolioTranslation.InsertUserId = userId;
            var x = await _fileService.SaveFile(dto.Attachment, "PortfolioTranslationFiles");
            portfolioTranslation.Attachment = x;
            await _Db.PortoFolioTranslations.AddAsync(portfolioTranslation);
            await _Db.SaveChangesAsync();
            var entity = _Db.PortoFolioTranslations.Include(x => x.Language).Include(x => x.Category).SingleOrDefault(x => x.Id == portfolioTranslation.Id);

            return _mapper.Map<PortfolioTranslationVM>(entity);
        }
        
        public async Task<PortfolioTranslationVM> Edit(string userId, UpdatePortfolioTranslationDto dto)
        {
            var portfolioTranslation = _Db.PortoFolioTranslations.SingleOrDefault(x => x.Id == dto.Id);
            if (portfolioTranslation == null)
            {
                throw new NotFoundException();
            }
           
            await _fileService.DeleteFile(portfolioTranslation.Attachment);
            _mapper.Map(dto, portfolioTranslation);
            portfolioTranslation.UpdateUserId = userId;
            var path = await _fileService.SaveFile(dto.Attachment, "PortfolioTranslationFiles");
            portfolioTranslation.Attachment = path;
            _Db.Update(portfolioTranslation);
            await _Db.SaveChangesAsync();
            return _mapper.Map<PortfolioTranslationVM>(portfolioTranslation);
        }

        public async Task Delete(string userId, int Id)
        {
            var portfolioTranslation = _Db.PortoFolioTranslations.SingleOrDefault(x => x.Id == Id);
            if (portfolioTranslation == null)
            {
                throw new NotFoundException();
            }
            portfolioTranslation.DeletedAt = DateTime.Now;
            portfolioTranslation.DeleteUserId = userId;
            _Db.Update(portfolioTranslation);
            await _Db.SaveChangesAsync();
        }


        public List<PortfolioTranslationVM> SearchAndFilter(SearchAndFilterDto dto)
        {
            var result = _Db.PortoFolioTranslations.WhereIf(dto.Title != null, s => s.Title.StartsWith(dto.Title))
                                                   .WhereIf(dto.Description != null, s => s.Description.Contains(dto.Description))
                                                   .WhereIf(dto.LanguageId != null, s => s.LanguageId == dto.LanguageId)
                                                   .WhereIf(dto.CategoryId != null, s => s.CategoryId == dto.CategoryId).Take(dto.Rows).ToList();
            return _mapper.Map<List<PortfolioTranslationVM>>(result);
        }
    }

    static class CollectionExtensions
    {
        public static IQueryable<TSource> WhereIf<TSource>(
            this IQueryable<TSource> source,
            bool condition,
            Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }
    }
}
