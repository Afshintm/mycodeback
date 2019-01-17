using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DataBaseServices.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EssenceEvent",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false, defaultValue: new Guid("51097424-9d16-4d39-84a7-cb1e63924f15")),
                    Account = table.Column<long>(nullable: false),
                    PanelTime = table.Column<string>(nullable: true),
                    ServerTime = table.Column<string>(nullable: true),
                    ServiceProvider = table.Column<int>(nullable: true),
                    ServiceType = table.Column<int>(nullable: true),
                    uid = table.Column<Guid>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Severity = table.Column<int>(nullable: true),
                    DetailsJson = table.Column<string>(nullable: true),
                    IsMobile = table.Column<bool>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    HorizontalAccuracy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UQ_EssenceEvent_EventId", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "HCSEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<Guid>(nullable: false, defaultValue: new Guid("96f68b6b-4c8f-43be-817a-429455c65aa3")),
                    OriginalEventId = table.Column<Guid>(nullable: false),
                    Account = table.Column<long>(nullable: false),
                    PanelTime = table.Column<string>(nullable: true),
                    ServerTime = table.Column<string>(nullable: true),
                    ServiceProvider = table.Column<int>(nullable: true),
                    ServiceType = table.Column<int>(nullable: true),
                    Code = table.Column<int>(nullable: false),
                    Severity = table.Column<int>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    HorizontalAccuracy = table.Column<int>(nullable: true),
                    IsMobile = table.Column<bool>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true),
                    DeviceType = table.Column<int>(nullable: true),
                    DeviceDescription = table.Column<string>(nullable: true),
                    PowerFailureDuration = table.Column<string>(nullable: true),
                    PowerRestoredDuration = table.Column<string>(nullable: true),
                    BatteryLevel = table.Column<int>(nullable: true),
                    LastContactTime = table.Column<string>(nullable: true),
                    ActivityType = table.Column<int>(nullable: true),
                    DurationInRoom = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: true),
                    ExitTime = table.Column<string>(nullable: true),
                    PeriodStartTime = table.Column<string>(nullable: true),
                    PeriodEndTime = table.Column<string>(nullable: true),
                    MaximumOutOfHomeDuration = table.Column<string>(nullable: true),
                    EntryTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCSEvent_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCSEvent_EssenceEvent",
                        column: x => x.OriginalEventId,
                        principalTable: "EssenceEvent",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_HCSEvent_EventId",
                table: "HCSEvent",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HCSEvent_OriginalEventId",
                table: "HCSEvent",
                column: "OriginalEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HCSEvent");

            migrationBuilder.DropTable(
                name: "EssenceEvent");
        }
    }
}
