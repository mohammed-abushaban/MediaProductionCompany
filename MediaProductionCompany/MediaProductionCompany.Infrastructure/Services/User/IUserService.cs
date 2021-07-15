using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.User
{
    public interface IUserService
    {
        Task<List<UserListVM>> Index(string s);
        Task<UserVM> Details(string Id);
        Task<UserVM> Create(string UserId, RegisterUserDto dto);
        Task<UserVM> Update(string UserId, UpdateUserDto dto);
        Task Delete(string userId, string Id);
        Task<List<string>> AutoComplete(string s);
    }
}
