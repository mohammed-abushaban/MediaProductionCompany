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

        public DbSet<CategoryDbEntity> Categories { get; set; }
        public DbSet<LanguageDbEntity> Languages { get; set; }
        public DbSet<CountryDbEntity> Countries { get; set; }
        public DbSet<PortfolioDbEntity> PortoFolios { get; set; }
        public DbSet<PortfolioTranslationDbEntity> PortoFolioTranslations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CategoryDbEntity>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<CountryDbEntity>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<LanguageDbEntity>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<PortfolioDbEntity>().HasQueryFilter(x => x.DeletedAt == null);
            builder.Entity<PortfolioTranslationDbEntity>().HasQueryFilter(x => x.DeletedAt == null);

        }
    }
}
