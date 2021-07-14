using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Data.DbEntity
{
    public class PortfolioTranslationDbEntity : BaseDbEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public int PortoFolioId { get; set; }
        public PortfolioDbEntity PortoFolio { get; set; }
        public int CategoryId { get; set; }
        public CategoryDbEntity Category { get; set; }
        public int LanguageId { get; set; }
        public LanguageDbEntity Language { get; set; }
    }
}
