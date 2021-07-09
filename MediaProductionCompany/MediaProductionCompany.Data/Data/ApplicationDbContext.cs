using MediaProductionCompany.Data.DbEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaProductionCompany.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDbEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserRoleDbEntity>().HasKey(x => new { x.RoleId, x.UserId});
        }

        public DbSet<CategoryDbEntity> Categories { get; set; }
        public DbSet<LanguageDbEntity> Languages { get; set; }
        public DbSet<CountryDbEntity> Countries { get; set; }
        public DbSet<PortoFolioDbEntity> PortoFolios { get; set; }
        public DbSet<PortoFolioTranslationDbEntity> PortoFolioTranslations { get; set; }
        public DbSet<RoleDbEntity> Types { get; set; }

    }
}
