using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configurations
{
    internal class EventConfigurations : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(e => e.Price)
                .HasColumnType("decimal(18,2)");
            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.UpdatedAt)
                .IsRequired()
                .HasComputedColumnSql("GETDATE()");
        }
    }
}


