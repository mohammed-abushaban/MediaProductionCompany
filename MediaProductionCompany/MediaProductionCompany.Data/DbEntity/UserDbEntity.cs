using MediaProductionCompany.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Data.DbEntity
{
    public class UserDbEntity : IdentityUser
    {
        public string FullName { get; set; }
        public CountryDbEntity County { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public string InsertUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string DeleteUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public UserType UserType { get; set; }


        [NotMapped]
        public bool IsDeleted
        {
            get
            {
                return DeletedAt.HasValue;
            }
            set { }
        }
    }
}
