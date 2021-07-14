using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.ViewModels;
using MediaProductionCompany.Data;
using MediaProductionCompany.Data.DbEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private ApplicationDbContext _DB;
        private SignInManager<UserDbEntity> _signInManager;

        public AuthService(ApplicationDbContext DB, SignInManager<UserDbEntity> signInManager)
        {
            _DB = DB;
            _signInManager = signInManager;
        }


        public async Task SaveFcmToken(string userId)
        {
            var user = await _DB.Users.SingleOrDefaultAsync(x => x.Id == userId && !x.IsDeleted);
            _DB.Users.Update(user);
            await _DB.SaveChangesAsync();
        }

        public async Task<LoginResponseVM> LoginAsync(LoginDto dto)
        {
            var user = _DB.Users.SingleOrDefault(x => x.UserName == dto.Username && !x.IsDeleted);

            if (user == null)
            {
                //throw new InvalidUsernameException();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (result.Succeeded)
            {
                _DB.Users.Update(user);
                _DB.SaveChanges();

                var token = GenerateAccessToken(user);
                var response = new LoginResponseVM();
                response.Token = token;
                response.User = new UserVM()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UpdatedAt = user.UpdatedAt,
                };
                return response;
            }
            return null;
        }
        private TokenVM GenerateAccessToken(UserDbEntity user)
        {
            var claims = new List<Claim>(){
              new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
              new Claim("UserId", user.Id),
              new Claim(JwtRegisteredClaimNames.Email, user.Email),
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("jklfdsjklfsdjklksdfopsfiopw"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMonths(1);
            var accessToken = new JwtSecurityToken("https://localhost:44338/",
                "https://localhost:44338/",
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken);
            var response = new TokenVM();
            response.AcessToken = AccessToken;
            response.ExpireAt = expires;
            return response;
        }
    }
}
