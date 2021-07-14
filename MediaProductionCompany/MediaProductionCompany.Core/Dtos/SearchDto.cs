using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.Dtos
{
    public class SearchDto
    {
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public int NumberOfRows { get; set; }

    }
}
