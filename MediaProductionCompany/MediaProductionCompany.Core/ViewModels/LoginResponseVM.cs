using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.ViewModels
{
    public class LoginResponseVM
    {
        public UserVM User { get; set; }

        public TokenVM Token { get; set; }

    }
}
