using CodeAlpha_SimpleUrlShortener.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_SimpleUrlShortener.DAL.Context.Configurations
{
    public class UrlMappingConfiguration : IEntityTypeConfiguration<UrlMapping>
    {
        public void Configure(EntityTypeBuilder<UrlMapping> builder)
        {
            builder.ToTable("UrlMappings");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OriginalUrl)
                .IsRequired()
                .HasMaxLength(2048);

            builder.Property(x => x.ShortCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => x.ShortCode)
                .IsUnique();

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.ClickCount)
                .HasDefaultValue(0);
        }
    }
}
