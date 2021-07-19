using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Data.DbEntity
{
    public class PortfolioDbEntity : BaseDbEntity
    {

        public string Title { get; set; }
        //TODO : remove user ID 

        public string UserId { get; set; }
        public UserDbEntity User { get; set; }
    }
}
