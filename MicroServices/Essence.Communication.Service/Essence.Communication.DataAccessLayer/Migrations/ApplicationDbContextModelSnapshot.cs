﻿// <auto-generated />
using System;
using Essence.Communication.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Essence.Communication.DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Application")
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Essence.Communication.Models.Dtos.EssenceEventObjectStructure", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("6be43ac7-f584-491f-bf05-bdd62567adfb");

                    b.Property<int>("Account");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 1, 25, 1, 7, 53, 724, DateTimeKind.Utc).AddTicks(9400));

                    b.Property<string>("PanelTime");

                    b.Property<string>("ServerTime");

                    b.Property<int?>("ServiceProvider");

                    b.Property<int?>("ServiceType");

                    b.Property<string>("Vendor")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasName("PK_EssenceEvent_Id");

                    b.ToTable("EssenceEvent");
                });

            modelBuilder.Entity("Essence.Communication.Models.EventBase", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("84129867-6f34-4b35-8dc6-d377ce6c3b13");

                    b.Property<int>("Account");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 1, 25, 1, 7, 53, 693, DateTimeKind.Utc).AddTicks(5967));

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("HSCCode");

                    b.Property<bool?>("IsMobile");

                    b.Property<string>("PanelTime");

                    b.Property<string>("ServerTime");

                    b.Property<int?>("ServiceProvider");

                    b.Property<int?>("ServiceType");

                    b.Property<int>("Severity");

                    b.Property<string>("UserID");

                    b.Property<string>("VendorEventId");

                    b.Property<string>("VendorType")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasName("PK_HCSEvent_Id");

                    b.ToTable("Event");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EventBase");
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.BatteryDetails>", b =>
                {
                    b.HasBaseType("Essence.Communication.Models.EventBase");

                    b.HasDiscriminator().HasValue("Event<BatteryDetails>");
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.EmergencyPanicDetails>", b =>
                {
                    b.HasBaseType("Essence.Communication.Models.EventBase");

                    b.HasDiscriminator().HasValue("Event<EmergencyPanicDetails>");
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.FallAlertDetails>", b =>
                {
                    b.HasBaseType("Essence.Communication.Models.EventBase");

                    b.HasDiscriminator().HasValue("Event<FallAlertDetails>");
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.PanelStatusDetails>", b =>
                {
                    b.HasBaseType("Essence.Communication.Models.EventBase");

                    b.HasDiscriminator().HasValue("Event<PanelStatusDetails>");
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.PowerDetails>", b =>
                {
                    b.HasBaseType("Essence.Communication.Models.EventBase");

                    b.HasDiscriminator().HasValue("Event<PowerDetails>");
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.StayHomeDetails>", b =>
                {
                    b.HasBaseType("Essence.Communication.Models.EventBase");

                    b.HasDiscriminator().HasValue("Event<StayHomeDetails>");
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.UnexpectedActivityDetails>", b =>
                {
                    b.HasBaseType("Essence.Communication.Models.EventBase");

                    b.HasDiscriminator().HasValue("Event<UnexpectedActivityDetails>");
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.UnexpectedEntryExitDetails>", b =>
                {
                    b.HasBaseType("Essence.Communication.Models.EventBase");

                    b.HasDiscriminator().HasValue("Event<UnexpectedEntryExitDetails>");
                });

            modelBuilder.Entity("Essence.Communication.Models.Dtos.EssenceEventObjectStructure", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.Dtos.EssenceEventObject", "Event", b1 =>
                        {
                            b1.Property<string>("EssenceEventObjectStructureId")
                                .ValueGeneratedOnAdd();

                            b1.Property<int>("Code");

                            b1.Property<string>("Details");

                            b1.Property<bool?>("IsMobile");

                            b1.Property<int>("Severity");

                            b1.HasKey("EssenceEventObjectStructureId");

                            b1.ToTable("EssenceEvent","Application");

                            b1.HasOne("Essence.Communication.Models.Dtos.EssenceEventObjectStructure")
                                .WithOne("Event")
                                .HasForeignKey("Essence.Communication.Models.Dtos.EssenceEventObject", "EssenceEventObjectStructureId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Essence.Communication.Models.ValueObjects.Location", "Location", b2 =>
                                {
                                    b2.Property<string>("EssenceEventObjectStructureId")
                                        .ValueGeneratedOnAdd();

                                    b2.Property<int?>("HorizontalAccuracy");

                                    b2.Property<string>("Latitude");

                                    b2.Property<string>("Longitude");

                                    b2.HasKey("EssenceEventObjectStructureId");

                                    b2.ToTable("EssenceEvent","Application");

                                    b2.HasOne("Essence.Communication.Models.Dtos.EssenceEventObject")
                                        .WithOne("Location")
                                        .HasForeignKey("Essence.Communication.Models.ValueObjects.Location", "EssenceEventObjectStructureId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Essence.Communication.Models.EventBase", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.ValueObjects.EmergencyCategory", "EmergencyCategory", b1 =>
                        {
                            b1.Property<string>("EventBaseId")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("Description")
                                .HasColumnName("EmergencyDescriptoin");

                            b1.Property<int>("Level")
                                .HasColumnName("EmergencyLevel");

                            b1.HasKey("EventBaseId");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.EventBase")
                                .WithOne("EmergencyCategory")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.EmergencyCategory", "EventBaseId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Essence.Communication.Models.ValueObjects.Location", "Location", b1 =>
                        {
                            b1.Property<string>("EventBaseId")
                                .ValueGeneratedOnAdd();

                            b1.Property<int?>("HorizontalAccuracy")
                                .HasColumnName("HorizontalAccuracy");

                            b1.Property<string>("Latitude")
                                .HasColumnName("Latitude");

                            b1.Property<string>("Longitude")
                                .HasColumnName("Longitude");

                            b1.HasKey("EventBaseId");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.EventBase")
                                .WithOne("Location")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.Location", "EventBaseId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.BatteryDetails>", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.ValueObjects.BatteryDetails", "Details", b1 =>
                        {
                            b1.Property<string>("Event<BatteryDetails>Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<int>("BatteryLevel");

                            b1.Property<string>("DeviceDescription");

                            b1.Property<int>("DeviceId");

                            b1.Property<int>("DeviceType");

                            b1.HasKey("Event<BatteryDetails>Id");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.BatteryDetails>")
                                .WithOne("Details")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.BatteryDetails", "Event<BatteryDetails>Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.EmergencyPanicDetails>", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.ValueObjects.EmergencyPanicDetails", "Details", b1 =>
                        {
                            b1.Property<string>("Event<EmergencyPanicDetails>Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("DeviceDescription")
                                .HasColumnName("EmergencyPanicDetails_Details_DeviceDescription");

                            b1.Property<int>("DeviceId")
                                .HasColumnName("EmergencyPanicDetails_Details_DeviceId");

                            b1.Property<int>("DeviceType")
                                .HasColumnName("EmergencyPanicDetails_Details_DeviceType");

                            b1.HasKey("Event<EmergencyPanicDetails>Id");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.EmergencyPanicDetails>")
                                .WithOne("Details")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.EmergencyPanicDetails", "Event<EmergencyPanicDetails>Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.FallAlertDetails>", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.ValueObjects.FallAlertDetails", "Details", b1 =>
                        {
                            b1.Property<string>("Event<FallAlertDetails>Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<int>("Activitytype");

                            b1.Property<string>("DeviceDescription")
                                .HasColumnName("FallAlertDetails_Details_DeviceDescription");

                            b1.Property<int>("DeviceId")
                                .HasColumnName("FallAlertDetails_Details_DeviceId");

                            b1.Property<int>("DeviceType")
                                .HasColumnName("FallAlertDetails_Details_DeviceType");

                            b1.Property<string>("DurationInRoom");

                            b1.HasKey("Event<FallAlertDetails>Id");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.FallAlertDetails>")
                                .WithOne("Details")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.FallAlertDetails", "Event<FallAlertDetails>Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.PanelStatusDetails>", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.ValueObjects.PanelStatusDetails", "Details", b1 =>
                        {
                            b1.Property<string>("Event<PanelStatusDetails>Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("LastContactTime");

                            b1.HasKey("Event<PanelStatusDetails>Id");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.PanelStatusDetails>")
                                .WithOne("Details")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.PanelStatusDetails", "Event<PanelStatusDetails>Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.PowerDetails>", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.ValueObjects.PowerDetails", "Details", b1 =>
                        {
                            b1.Property<string>("Event<PowerDetails>Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("DeviceDescription")
                                .HasColumnName("PowerDetails_Details_DeviceDescription");

                            b1.Property<int>("DeviceId")
                                .HasColumnName("PowerDetails_Details_DeviceId");

                            b1.Property<int>("DeviceType")
                                .HasColumnName("PowerDetails_Details_DeviceType");

                            b1.Property<string>("PowerFailureDuration");

                            b1.Property<string>("PowerRestoredDuration");

                            b1.HasKey("Event<PowerDetails>Id");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.PowerDetails>")
                                .WithOne("Details")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.PowerDetails", "Event<PowerDetails>Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.StayHomeDetails>", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.ValueObjects.StayHomeDetails", "Details", b1 =>
                        {
                            b1.Property<string>("Event<StayHomeDetails>Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("EntryTime");

                            b1.Property<string>("ExitTime");

                            b1.Property<string>("MaximumOutOfHomeDuration");

                            b1.Property<string>("PeriodEndTime");

                            b1.Property<string>("PeriodStartTime");

                            b1.HasKey("Event<StayHomeDetails>Id");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.StayHomeDetails>")
                                .WithOne("Details")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.StayHomeDetails", "Event<StayHomeDetails>Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.UnexpectedActivityDetails>", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.ValueObjects.UnexpectedActivityDetails", "Details", b1 =>
                        {
                            b1.Property<string>("Event<UnexpectedActivityDetails>Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("DeviceDescription")
                                .HasColumnName("UnexpectedActivityDetails_Details_DeviceDescription");

                            b1.Property<int>("DeviceId")
                                .HasColumnName("UnexpectedActivityDetails_Details_DeviceId");

                            b1.Property<int>("DeviceType")
                                .HasColumnName("UnexpectedActivityDetails_Details_DeviceType");

                            b1.Property<float>("Grade");

                            b1.HasKey("Event<UnexpectedActivityDetails>Id");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.UnexpectedActivityDetails>")
                                .WithOne("Details")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.UnexpectedActivityDetails", "Event<UnexpectedActivityDetails>Id")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.UnexpectedEntryExitDetails>", b =>
                {
                    b.OwnsOne("Essence.Communication.Models.ValueObjects.UnexpectedEntryExitDetails", "Details", b1 =>
                        {
                            b1.Property<string>("Event<UnexpectedEntryExitDetails>Id")
                                .ValueGeneratedOnAdd();

                            b1.Property<string>("DeviceDescription")
                                .HasColumnName("UnexpectedEntryExitDetails_Details_DeviceDescription");

                            b1.Property<int>("DeviceId")
                                .HasColumnName("UnexpectedEntryExitDetails_Details_DeviceId");

                            b1.Property<int>("DeviceType")
                                .HasColumnName("UnexpectedEntryExitDetails_Details_DeviceType");

                            b1.HasKey("Event<UnexpectedEntryExitDetails>Id");

                            b1.ToTable("Event","Application");

                            b1.HasOne("Essence.Communication.Models.Event<Essence.Communication.Models.ValueObjects.UnexpectedEntryExitDetails>")
                                .WithOne("Details")
                                .HasForeignKey("Essence.Communication.Models.ValueObjects.UnexpectedEntryExitDetails", "Event<UnexpectedEntryExitDetails>Id")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Essence.Communication.Models.ValueObjects.Period", "Period", b2 =>
                                {
                                    b2.Property<string>("UnexpectedEntryExitDetailsEvent<UnexpectedEntryExitDetails>Id")
                                        .ValueGeneratedOnAdd();

                                    b2.Property<bool>("Is24Hours");

                                    b2.Property<string>("PeriodEndTime");

                                    b2.Property<string>("PeriodStartTime");

                                    b2.HasKey("UnexpectedEntryExitDetailsEvent<UnexpectedEntryExitDetails>Id");

                                    b2.ToTable("Event","Application");

                                    b2.HasOne("Essence.Communication.Models.ValueObjects.UnexpectedEntryExitDetails")
                                        .WithOne("Period")
                                        .HasForeignKey("Essence.Communication.Models.ValueObjects.Period", "UnexpectedEntryExitDetailsEvent<UnexpectedEntryExitDetails>Id")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
