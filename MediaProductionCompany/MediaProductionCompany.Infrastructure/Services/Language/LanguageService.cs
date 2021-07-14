using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data;
using MediaProductionCompany.Data.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Language
{
    public class LanguageService : ILanguageService
    {
        private readonly ApplicationDbContext _Db;
        private readonly IMapper _mapper;

        public LanguageService(ApplicationDbContext Db, IMapper mapper)
        {
            _Db = Db;
            _mapper = mapper;
        }

        public async Task<List<LanguageVM>> Index()
        {
            return _mapper.Map<List<LanguageVM>>(_Db.Languages.ToList());
        }

        public async Task<LanguageVM> Create(string UserId, CreateLanguageDto dto)
        {
            var Language = _mapper.Map<LanguageDbEntity>(dto);
            Language.InsertUserId = UserId;
            var result = await _Db.Languages.AddAsync(Language);
            await _Db.SaveChangesAsync();
            return _mapper.Map<LanguageVM>(result.Entity);
        }
    }
}
