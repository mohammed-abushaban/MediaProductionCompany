using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.Dtos
{
    public class SearchAndFilterDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int Rows { get; set; }
        public int? LanguageId { get; set; }

    }
}
