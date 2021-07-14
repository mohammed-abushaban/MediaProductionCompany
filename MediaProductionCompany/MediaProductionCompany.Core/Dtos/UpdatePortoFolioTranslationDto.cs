using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Core.Dtos
{
    public class UpdatePortoFolioTranslationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Attachment { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
    }
}
