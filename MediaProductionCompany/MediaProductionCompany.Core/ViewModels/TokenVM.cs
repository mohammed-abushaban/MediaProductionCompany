using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.ViewModels
{
    public class TokenVM
    {
        public string AcessToken { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
