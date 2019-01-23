using Essence.Communication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Essence.Communication.DataAccessLayer.Configurations
{
    public class EventConfig : IEntityTypeConfiguration<EventBase>
    {
        public void Configure(EntityTypeBuilder<EventBase> builder)
        {
            builder.HasKey(h => h.Id)
                .HasName("PK_HCSEvent_Id");

            //Fk
            builder.HasOne(h => h.VendorEvent).
                WithMany(o => o.HSCEvents).
                HasForeignKey(h => h.VendorEventId).
                HasConstraintName("FK_Event_VendorEvent");

            //Default value
            builder.Property(h => h.Id)
                .HasDefaultValue(Guid.NewGuid());
            builder.Property(h => h.CreateDate)
                .HasDefaultValue(DateTime.UtcNow);

            builder.OwnsOne(l => l.Location);
        }
    }

    //TODO: change essence event to vender event
    public class VendorEventConfig : IEntityTypeConfiguration<VendorEvent>
    {
        public void Configure(EntityTypeBuilder<VendorEvent> builder)
        {
            builder.HasKey(h => h.Id)
                .HasName("PK_VendorEvent_Id");

            //Default value
            builder.Property(h => h.Id)
                .HasDefaultValue(Guid.NewGuid());

            builder.Property(h => h.CreateDate)
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}
