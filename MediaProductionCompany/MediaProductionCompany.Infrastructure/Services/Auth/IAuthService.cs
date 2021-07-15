using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseVM> LoginAsync(LoginDto dto);
        Task<LoginResponseVM> SignUpAsync(RegisterUserDto dto);
    }
}
