using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaProductionCompany.Data.DbEntity
{
    public class BaseDbEntity
    {
        public int Id { get; set; }
        public UserDbEntity InsertUser { get; set; }
        public string InsertUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserDbEntity UpdateUser { get; set; }
        public string? UpdateUserId  { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserDbEntity DeleteUser { get; set; }
        public string? DeleteUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public BaseDbEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }
    }
}
