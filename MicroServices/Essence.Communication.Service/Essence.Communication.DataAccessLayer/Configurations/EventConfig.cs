using Essence.Communication.Models;
using Essence.Communication.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Essence.Communication.DataAccessLayer.Configurations
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

            var vendorTypeConverter = new ValueConverter<Vendor, string>(
                v => v.ToString(),
                v => (Vendor)Enum.Parse(typeof(Vendor), v));

            builder.Property(h => h.VenderType).HasConversion(vendorTypeConverter);

            builder.Property(h => h.CreateDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder.OwnsOne(l => l.Location).Property(c => c.Latitude).HasColumnName("Latitude");
            builder.OwnsOne(l => l.Location).Property(c => c.Longitude).HasColumnName("Longitude"); ;
            builder.OwnsOne(l => l.Location).Property(c => c.HorizontalAccuracy).HasColumnName("HorizontalAccuracy"); ;

            builder.OwnsOne(l => l.EmergencyCategory).Property(c => c.Level).HasColumnName("EmergencyLevel");
            builder.OwnsOne(l => l.EmergencyCategory).Property(c => c.Description).HasColumnName("EmergencyDescriptoin");
        }
    } 
}
