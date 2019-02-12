using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Essence.Communication.DbContexts.Configurations;
using Services.Utilities.DataAccess;
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Essence.Communication.DbContexts
{
    public class ApplicationDbContext : DbContextBase<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EssenceEventObjectStructure> EssenceEvents { get; set; }

        //Event hierarchy
        public DbSet<EventBase> Events { get; set; }
        public DbSet<Event<UnexpectedActivityDetails>> UnexpectedActivityEvents { get; set; }
        public DbSet<Event<UnexpectedEntryExitDetails>> UnexpectedEntryExitEvents { get; set; }
        public DbSet<Event<StayHomeDetails>> StayHomeEvent { get; set; }
        public DbSet<Event<PowerDetails>> PoweEvents { get; set; }
        public DbSet<Event<BatteryDetails>> BatteryEvents { get; set; }
        public DbSet<Event<PanelStatusDetails>> PanelStatusEvents { get; set; }
        public DbSet<Event<FallAlertDetails>> FallAlertEvents { get; set; }
        public DbSet<Event<EmergencyPanicDetails>> EmergencyPanicEvents { get; set; }

        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserReference> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Application");

            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new VendorEventConfig());
            modelBuilder.ApplyConfiguration(new AccountUserConfig());

            //set value objects
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
