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
            var result = await _Db.PortoFolioTranslations.AddAsync(portfolioTranslation);
            await _Db.SaveChangesAsync();
            await _fileService.SaveFile(dto.Attachment, "PortfolioTranslationFiles");
            return _mapper.Map<PortfolioTranslationVM>(result.Entity);
        }
        
        public async Task<PortfolioTranslationVM> Edit(string userId, UpdatePortfolioTranslationDto dto)
        {
            var portfolioTranslation = _Db.PortoFolioTranslations.SingleOrDefault(x => x.Id == dto.Id);
            if (portfolioTranslation == null)
            {
                throw new NotFoundException();
            }
            _mapper.Map(dto, portfolioTranslation);
            portfolioTranslation.UpdateUserId = userId;
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
    }
}
