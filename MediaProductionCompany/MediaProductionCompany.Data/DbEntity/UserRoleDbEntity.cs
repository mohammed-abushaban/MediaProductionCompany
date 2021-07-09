using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Data.DbEntity
{
    public class UserRoleDbEntity
    {
        public string UserId { get; set; }
        public UserDbEntity User { get; set; }
        public int RoleId { get; set; }
        public RoleDbEntity Role { get; set; }
    }
}
