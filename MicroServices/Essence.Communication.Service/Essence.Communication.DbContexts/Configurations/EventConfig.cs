using Essence.Communication.Models;
using Essence.Communication.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Essence.Communication.DbContexts.Configurations
{
    public class EventConfig : IEntityTypeConfiguration<EventBase>
    {
        public void Configure(EntityTypeBuilder<EventBase> builder)
        {
            builder.HasKey(h => h.Id)
                .HasName("PK_HCSEvent_Id");

            //Default value
            DbContextHelper.SetIdDefaultGuidValue(builder);

            //fk  
            builder.HasOne(e => e.Vendor).WithMany(v => v.HSCEvents).HasForeignKey("VendorId");
            builder.HasOne(e => e.Account).WithMany(a => a.HSCEvents).HasForeignKey("AccountId");

            //convert enum into string
            builder.Property(h => h.AlertType).HasConversion(DbContextHelper.GetEnumValueConverter<AlertType>());
            builder.Property(h => h.Status).HasConversion(DbContextHelper.GetEnumValueConverter<EventStatus>());

            builder.Property(h => h.CreateDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder.OwnsOne(l => l.Location).Property(c => c.Latitude).HasColumnName("Latitude");
            builder.OwnsOne(l => l.Location).Property(c => c.Longitude).HasColumnName("Longitude"); ;
            builder.OwnsOne(l => l.Location).Property(c => c.HorizontalAccuracy).HasColumnName("HorizontalAccuracy");         
        }

    } 

    
}
