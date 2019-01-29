﻿using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Essence.Communication.DbContexts.Configurations;
namespace Essence.Communication.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EssenceEventObjectStructure> EssenceEvent { get; set; }

        //Event hierarchy
        public DbSet<EventBase> Event { get; set; }
        public DbSet<Event<UnexpectedActivityDetails>> UnexpectedActivityEvent { get; set; }
        public DbSet<Event<UnexpectedEntryExitDetails>> UnexpectedEntryExitEvent { get; set; }
        public DbSet<Event<StayHomeDetails>> StayHomeEvent { get; set; }
        public DbSet<Event<PowerDetails>> PoweEvent { get; set; }
        public DbSet<Event<BatteryDetails>> BatteryEvent { get; set; }
        public DbSet<Event<PanelStatusDetails>> PanelStatusEvent { get; set; }
        public DbSet<Event<FallAlertDetails>> FallAlertEvent { get; set; }
        public DbSet<Event<EmergencyPanicDetails>> EmergencyPanicEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Application");

            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new VendorEventConfig());

            //value objects
            modelBuilder.Entity<Event<UnexpectedActivityDetails>>().OwnsOne(s => s.Details);
            modelBuilder.Entity<Event<UnexpectedEntryExitDetails>>().OwnsOne(s => s.Details).OwnsOne(p => p.Period);
            modelBuilder.Entity<Event<StayHomeDetails>>().OwnsOne(s => s.Details);
            modelBuilder.Entity<Event<PowerDetails>>().OwnsOne(s => s.Details);
            modelBuilder.Entity<Event<BatteryDetails>>().OwnsOne(s => s.Details);
            modelBuilder.Entity<Event<PanelStatusDetails>>().OwnsOne(s => s.Details);
            modelBuilder.Entity<Event<FallAlertDetails>>().OwnsOne(s => s.Details);
            modelBuilder.Entity<Event<EmergencyPanicDetails>>().OwnsOne(s => s.Details);
        }

    }
}