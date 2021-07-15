using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.Exceptions;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data;
using MediaProductionCompany.Data.DbEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _Db;
        private readonly IMapper _mapper;
        private readonly UserManager<UserDbEntity> _userManager;

        public UserService(ApplicationDbContext db, IMapper mapper, UserManager<UserDbEntity> userManager)
        {
            _Db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<UserListVM>> Index(string s)
        {
            var users = from User in _Db.Users
                        select User;

            if (!String.IsNullOrEmpty(s))
            {
                users = users.Where(x => x.FullName.Contains(s));
            }
            var result = await users.ToListAsync();
            return _mapper.Map<List<UserListVM>>(result);
        }

        public async Task<UserVM> Details(string Id)
        {
            var user = _Db.Users.Include(x => x.Country).SingleOrDefault(x => x.Id == Id);
            if (user == null)
            {
                throw new NotFoundException();
            }
            return _mapper.Map<UserVM>(user);
        }

        public async Task<UserVM> Create(string UserId, RegisterUserDto dto)
        {
            var user = _mapper.Map<UserDbEntity>(dto);
            user.CreatedAt = DateTime.Now;
            user.InsertUser = UserId;
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                return _mapper.Map<UserVM>(user);
            }
            else
            {
                throw new NotFoundException();
            }
        }
        public async Task<UserVM> Update(string UserId, UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            _mapper.Map(dto, user);
            user.UpdatedAt = DateTime.Now;
            user.InsertUser = UserId;
            await _userManager.UpdateAsync(user);
            return _mapper.Map<UserVM>(user);
        }


        public async Task Delete(string userId, string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            user.DeletedAt = DateTime.Now;
            user.DeleteUserId = userId;
            await _userManager.UpdateAsync(user);
        }

        public async Task<List<string>> AutoComplete(string s)
        {
            var users = from User in _Db.Users.ToList()
                        where User.FullName.StartsWith(s)
                        select User.FullName;
            return (List<string>) users;
        }
    }
}
