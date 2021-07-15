using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.ViewModels
{
    public class UserListVM
    {
        public string FullName { get; set; }
        public string InsertUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
