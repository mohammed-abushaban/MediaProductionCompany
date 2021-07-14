using MediaProductionCompany.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.ViewModels
{
    public class PortfolioFilterElementsVM
    {
        public List<CategoryVM> Categories { get; set; }
        public List<LanguageVM> Languages { get; set; }
    }
}
