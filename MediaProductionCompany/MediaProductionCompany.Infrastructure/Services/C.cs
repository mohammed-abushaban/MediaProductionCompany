//using MediaProductionCompany.Data.DbEntity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Infrastructure.Services
{
    public class C
    {
        private readonly RoleManager<IdentityRole> _roleManger;
        //private readonly UserManager<UserDbEntity> _userManger;


        public async Task InitRoles()
        {
            var rolesName = new List<string>();
            rolesName.Add("Admin");
            rolesName.Add("Employee");

            foreach(var role in rolesName)
            {
               await  _roleManger.CreateAsync(new IdentityRole(role));
            }
        }

        public async Task Demo()
        {
            //var user = _userManger.AddToRoleAsync(new UserDbEntity(), "Admin");
            //_userManger.role
        }
    }
}
