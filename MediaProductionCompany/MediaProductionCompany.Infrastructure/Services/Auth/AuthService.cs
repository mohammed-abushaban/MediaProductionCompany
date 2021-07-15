using AutoMapper;
using MediaProductionCompany.Core.Dtos;
using MediaProductionCompany.Core.Exceptions;
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
        private readonly ApplicationDbContext _DB;
        private readonly SignInManager<UserDbEntity> _signInManager;
        private readonly UserManager<UserDbEntity> _userManager;
        private readonly IMapper _mapper;

        public AuthService(ApplicationDbContext dB, SignInManager<UserDbEntity> signInManager, UserManager<UserDbEntity> userManager, IMapper mapper)
        {
            _DB = dB;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<LoginResponseVM> LoginAsync(LoginDto dto)
        {
            var user = _DB.Users.SingleOrDefault(x => x.UserName == dto.Username && x.DeletedAt == null);

            if (user == null)
            {
                throw new InvalidUsernameException();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            var s = await _userManager.IsInRoleAsync(user, "Admin");
            if (result.Succeeded)
            {
                _DB.Users.Update(user);
                _DB.SaveChanges();

                var token = GenerateAccessToken(user);
                var response = new LoginResponseVM
                {
                    Token = token,
                    User = new UserVM()
                    {
                        Id = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        UpdatedAt = user.UpdatedAt,
                    }
                };
                return response;
            }
            return null;
        }

        public async Task<LoginResponseVM> SignUpAsync(RegisterUserDto dto)
        {
            var user = _mapper.Map<UserDbEntity>(dto);
            user.CreatedAt = DateTime.Now;
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                var token = GenerateAccessToken(user);
                return new LoginResponseVM
                {
                    Token = token,
                    User = _mapper.Map<UserVM>(user)
                };
            }
            else
            {
                throw new NotFoundException();
            }
        }

        private static TokenVM GenerateAccessToken(UserDbEntity user)
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
            var accessToken = new JwtSecurityToken("https://localhost:44388/",
                "https://localhost:44388/",
                claims,
                expires: expires,
                signingCredentials: credentials
            );
            var AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken);
            return new TokenVM
            {
                AcessToken = AccessToken,
                ExpireAt = expires
            };
        }
    }
}
