using CodeAlpha_EventRegistrationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlpha_EventRegistrationSystem.DAL.Contexts.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Location).IsRequired().HasMaxLength(200);
            builder.Property(e => e.EventDate).IsRequired();
        }
    }
}
