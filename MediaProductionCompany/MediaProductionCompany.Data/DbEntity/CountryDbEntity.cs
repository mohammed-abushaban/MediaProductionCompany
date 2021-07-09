using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Data.DbEntity
{
    public class CountryDbEntity : BaseDbEntity
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public LanguageDbEntity Language { get; set; }
    }
}
