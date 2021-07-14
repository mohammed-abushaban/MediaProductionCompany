using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
