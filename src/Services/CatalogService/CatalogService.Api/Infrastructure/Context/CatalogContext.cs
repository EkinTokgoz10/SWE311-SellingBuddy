using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogService.Api.Core.Domain.Entities;
using CatalogService.Api.Infrastructure.EntityConfigurations;

namespace CatalogService.Api.Infrastructure.Context
{
    public class CatalogContext: DbContext
    {
        public const string DEFAULT_SCHEMA = "catalog";

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguraiton(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguraiton(new CatalogItemEntityTypeConfiguration());
            builder.ApplyConfiguraiton(new CatalogTypeEntityTypeConfiguration());
        }

    }
}