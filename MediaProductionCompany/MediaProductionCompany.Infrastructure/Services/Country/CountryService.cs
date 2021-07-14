using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.Exceptions;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data;
using MediaProductionCompany.Data.DbEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Country
{
    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext _Db;
        private readonly IMapper _mapper;

        public CountryService(ApplicationDbContext db, IMapper mapper)
        {
            _Db = db;
            _mapper = mapper;
        }

        public async Task<List<CountryVM>> Index()
        {
            return _mapper.Map<List<CountryVM>>(_Db.Countries.Include(x => x.Language).ToList());
        }

        public async Task<CountryDetailsVM> Details(int Id)
        {
            var Country = _Db.Countries.Include(x => x.Language).SingleOrDefault( x =>  x.Id == Id );
            if(Country == null)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<CountryDetailsVM>(Country);

        }

        public async Task<CountryVM> Create(string UserId, CreateCountryDto dto)
        {
            var country = _mapper.Map<CountryDbEntity>(dto);
            country.InsertUserId = UserId;
            var result = await _Db.Countries.AddAsync(country);
            await _Db.SaveChangesAsync();
            return _mapper.Map<CountryVM>(result.Entity);
        }

        public async Task Delete(string UserId, int Id)
        {
            var Country = _Db.Countries.SingleOrDefault(x => x.Id == Id);
            if(Country == null)
            {
                throw new NotFoundException();
            }
            Country.DeleteUserId = UserId;
            Country.DeletedAt = DateTime.Now;
            _Db.Countries.Update(Country);
            await _Db.SaveChangesAsync();
        }
    }
}
