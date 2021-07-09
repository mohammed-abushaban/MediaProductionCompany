using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Data.DbEntity
{
    public class PortoFolioDbEntity : BaseDbEntity
    {
        public string Title { get; set; }
        public string UserId { get; set; }
        public UserDbEntity User { get; set; }
    }
}
