using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogService.Api.Core.Domain.Entities;
using CatalogService.Api.Infrastructure.Context;

namespace CatalogService.Api.Infrastructure.EntityConfigurations
{
    class CatalogBrandEntityTypeConfigurations : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand", CatalogContext.DEFAULT_SCHEMA);

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .UseHilo("catalog_brand_hilo")
                .IsRequired();

                builder.Property(cb => cb.Brand)
                    .IsRequired()
                    .HasMaxLength(100);
        }
    }
}