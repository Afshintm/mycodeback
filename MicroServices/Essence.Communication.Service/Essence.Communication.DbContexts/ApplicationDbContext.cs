using Essence.Communication.Models;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Essence.Communication.DbContexts.Configurations;
using Services.Utilities.DataAccess;
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Essence.Communication.Models.Utility;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Essence.Communication.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Essence.Communication.DbContexts
{
    /// <summary>
    /// the 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbContext, IIdentityUserContext
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
        public DbSet<UserReference> UserRef { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 

            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole();
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Application");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Vendor>().ToTable("Vendor");
            modelBuilder.Entity<AccountGroup>().ToTable("AccountGroup");

            OnIdentityModelsCreating(modelBuilder);
            OnApplicationModelsCreating(modelBuilder);
        }

        private void  OnApplicationModelsCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new EssenceEventConfig());
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

            //seeding 
            modelBuilder.Entity<Vendor>().HasData(new Vendor(EventVendors.ESSENCE));

            //test seeding data
            modelBuilder.Entity<AccountGroup>().HasData(new AccountGroup() { Name = "TestGroup" });
        }

        private  void OnIdentityModelsCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfig());
            modelBuilder.ApplyConfiguration(new UserReferenceConfig());

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable( "Role", "Identity");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRole", "Identity");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaim", "Identity");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogin", "Identity");     
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaim", "Identity");

            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserToken", "Identity");
            });


        }
    }
}
