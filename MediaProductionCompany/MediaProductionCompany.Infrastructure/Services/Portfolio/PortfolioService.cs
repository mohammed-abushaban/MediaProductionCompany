using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.Exceptions;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data;
using MediaProductionCompany.Data.DbEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Portfolio
{
    public class PortfolioService : IPortfolioService
    {

        private readonly ApplicationDbContext _Db;
        private readonly IMapper _mapper;
        private readonly UserManager<UserDbEntity> _UserManager;

        public PortfolioService(ApplicationDbContext db, IMapper mapper, UserManager<UserDbEntity> UserManager)
        {
            _Db = db;
            _mapper = mapper;
            _UserManager = UserManager;
        }

        public async Task<List<PortfolioVM>> Index()
        {
            return _mapper.Map<List<PortfolioVM>>(_Db.PortoFolios.ToList());
        }

        public async Task<PortfolioVM> Create(string userId, CreatePortfolioDto dto)
        {
            var portfolio = _mapper.Map<PortfolioDbEntity>(dto);
            portfolio.InsertUserId = userId;
            var result = await _Db.PortoFolios.AddAsync(portfolio);
            await _Db.SaveChangesAsync();
            return _mapper.Map<PortfolioVM>(result.Entity);
        }

        public async Task<PortfolioVM> Edit(string userId, UpdatePortfolioDto dto)
        {
            var portfolio = _Db.PortoFolios.SingleOrDefault(x => x.Id == dto.Id);
            var user = _Db.Users.SingleOrDefault(x => x.Id == userId);
            if (portfolio == null || !(portfolio.UserId == userId && await _UserManager.IsInRoleAsync(user ,"Admin")))
            {
                throw new NotFoundException();
            }
            _mapper.Map(dto, portfolio);
            portfolio.UpdatedAt = DateTime.Now;
            portfolio.UpdateUserId = userId;
            await _Db.SaveChangesAsync();
            return _mapper.Map<PortfolioVM>(portfolio);
        }

        public async Task Delete(string userId, int Id)
        {
            var portfolio = _Db.PortoFolios.SingleOrDefault(x => x.Id == Id);
            if (portfolio == null)
            {
                throw new NotFoundException();
            }
            portfolio.DeletedAt = DateTime.Now;
            portfolio.DeleteUserId = userId;
            _Db.Update(portfolio);
            await _Db.SaveChangesAsync();
        }

    }
}
