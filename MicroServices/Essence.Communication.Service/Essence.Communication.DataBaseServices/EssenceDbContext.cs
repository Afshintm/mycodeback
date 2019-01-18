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
            modelBuilder.Entity<HSCEventDAO>()
                .HasKey(h => h.Id)
                .HasName("PK_HCSEvent_Id");

            modelBuilder.Entity<EssenceEventDAO>()
                .HasKey(e => e.EventId)
                .HasName("PK_EssenceEvent_Id");

            //Unique keys
            modelBuilder.Entity<HSCEventDAO>()
                .HasIndex(h => h.EventId)
                .IsUnique()
                .HasName("UQ_HCSEvent_EventId");

            modelBuilder.Entity<EssenceEventDAO>()
                .HasKey(e => e.EventId)
                .HasName("UQ_EssenceEvent_EventId");

            //Fk
            modelBuilder.Entity<HSCEventDAO>()
                     .HasOne(h => h.OriginalEvent)
                     .WithMany(o => o.HSCEvents)
                     .HasForeignKey(h => h.OriginalEventId)
                     .HasConstraintName("FK_HCSEvent_EssenceEvent");

            //Default value
            modelBuilder.Entity<HSCEventDAO>()
                .Property(h => h.EventId)
                .HasDefaultValue(Guid.NewGuid());

            modelBuilder.Entity<EssenceEventDAO>()
                .Property(e => e.EventId)
                .HasDefaultValue(Guid.NewGuid());   
        }

        public DbSet<EssenceEventDAO> EssenceEvent { get; set; }
        public DbSet<HSCEventDAO> HCSEvent { get; set; }
    }
}
