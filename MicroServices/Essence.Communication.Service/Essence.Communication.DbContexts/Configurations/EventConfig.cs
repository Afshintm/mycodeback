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
            builder.Property(h => h.Id)
                .HasDefaultValue(Guid.NewGuid().ToString())
                .IsRequired();

            //convert enum into string
            builder.Property(h => h.VendorType).HasConversion(DbContextHelper.GetEnumValueConverter<Vendor>());
            builder.Property(h => h.AlertType).HasConversion(DbContextHelper.GetEnumValueConverter<AlertType>());

            builder.Property(h => h.CreateDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder.OwnsOne(l => l.Location).Property(c => c.Latitude).HasColumnName("Latitude");
            builder.OwnsOne(l => l.Location).Property(c => c.Longitude).HasColumnName("Longitude"); ;
            builder.OwnsOne(l => l.Location).Property(c => c.HorizontalAccuracy).HasColumnName("HorizontalAccuracy");         
        }

    } 

    
}
