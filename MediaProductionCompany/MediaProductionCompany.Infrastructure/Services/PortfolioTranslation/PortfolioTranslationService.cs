using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data;
using MediaProductionCompany.Data.DbEntity;
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

        public PortfolioTranslationService(ApplicationDbContext db, IMapper mapper)
        {
            _Db = db;
            _mapper = mapper;
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
