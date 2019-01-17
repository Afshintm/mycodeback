using Essence.Communication.DataBaseServices.Daos;
using Microsoft.EntityFrameworkCore;
using System;

namespace Essence.Communication.DataBaseServices
{
    public class EventDbContext: DbContext
    {
        public EventDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Pk
            modelBuilder.Entity<HCSEvent>()
                .HasKey(h => h.Id)
                .HasName("PK_HCSEvent_Id");

            modelBuilder.Entity<EssenceEvent>()
                .HasKey(e => e.EventId)
                .HasName("PK_EssenceEvent_Id");

            //Unique keys
            modelBuilder.Entity<HCSEvent>()
                .HasIndex(h => h.EventId)
                .IsUnique()
                .HasName("UQ_HCSEvent_EventId");

            modelBuilder.Entity<EssenceEvent>()
                .HasKey(e => e.EventId)
                .HasName("UQ_EssenceEvent_EventId");

            //Fk
            modelBuilder.Entity<HCSEvent>()
                     .HasOne(h => h.OriginalEvent)
                     .WithMany(o => o.HCSEvents)
                     .HasForeignKey(h => h.OriginalEventId)
                     .HasConstraintName("FK_HCSEvent_EssenceEvent");

            //Default value
            modelBuilder.Entity<HCSEvent>()
                .Property(h => h.EventId)
                .HasDefaultValue(Guid.NewGuid());

            modelBuilder.Entity<EssenceEvent>()
                .Property(e => e.EventId)
                .HasDefaultValue(Guid.NewGuid());   
        }

        public DbSet<EssenceEvent> EssenceEvent { get; set; }
        public DbSet<HCSEvent> HCSEvent { get; set; }
    }
}
