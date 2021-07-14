using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.ViewModels
{
    public class CountryDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; }
        public string InsertUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}
