using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Application");

            migrationBuilder.CreateTable(
                name: "EssenceEvent",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, defaultValue: "95f4e838-c3db-4859-9484-2860773d4c81"),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 1, 24, 0, 59, 51, 282, DateTimeKind.Utc).AddTicks(6700)),
                    Vender = table.Column<string>(nullable: false),
                    Account = table.Column<int>(nullable: false),
                    Event_Code = table.Column<int>(nullable: false),
                    Event_Severity = table.Column<int>(nullable: false),
                    Event_Details = table.Column<string>(nullable: true),
                    Event_IsMobile = table.Column<bool>(nullable: true),
                    Event_Location_Latitude = table.Column<string>(nullable: true),
                    Event_Location_Longitude = table.Column<string>(nullable: true),
                    Event_Location_HorizontalAccuracy = table.Column<int>(nullable: false),
                    PanelTime = table.Column<string>(nullable: true),
                    ServerTime = table.Column<string>(nullable: true),
                    ServiceProvider = table.Column<int>(nullable: true),
                    ServiceType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssenceEvent_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, defaultValue: "ae159d69-deb2-4aa9-80b1-123afbc19398"),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 1, 24, 0, 59, 51, 254, DateTimeKind.Utc).AddTicks(9858)),
                    Account = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Severity = table.Column<int>(nullable: false),
                    PanelTime = table.Column<string>(nullable: true),
                    ServiceProvider = table.Column<int>(nullable: true),
                    ServiceType = table.Column<int>(nullable: true),
                    ServerTime = table.Column<string>(nullable: true),
                    IsMobile = table.Column<bool>(nullable: true),
                    Location_Latitude = table.Column<string>(nullable: true),
                    Location_Longitude = table.Column<string>(nullable: true),
                    Location_HorizontalAccuracy = table.Column<int>(nullable: false),
                    VenderType = table.Column<string>(nullable: false),
                    VendorEventId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Details_DeviceId = table.Column<int>(nullable: true),
                    Details_DeviceType = table.Column<int>(nullable: true),
                    Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_BatteryLevel = table.Column<int>(nullable: true),
                    EmergencyPanicDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    EmergencyPanicDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    EmergencyPanicDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    FallAlertDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    FallAlertDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    FallAlertDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_Activitytype = table.Column<int>(nullable: true),
                    Details_DurationInRoom = table.Column<string>(nullable: true),
                    Details_LastContactTime = table.Column<string>(nullable: true),
                    PowerDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    PowerDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    PowerDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_PowerFailureDuration = table.Column<string>(nullable: true),
                    Details_PowerRestoredDuration = table.Column<string>(nullable: true),
                    Details_ExitTime = table.Column<string>(nullable: true),
                    Details_PeriodStartTime = table.Column<string>(nullable: true),
                    Details_PeriodEndTime = table.Column<string>(nullable: true),
                    Details_MaximumOutOfHomeDuration = table.Column<string>(nullable: true),
                    Details_EntryTime = table.Column<string>(nullable: true),
                    UnexpectedActivityDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    UnexpectedActivityDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    UnexpectedActivityDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_Grade = table.Column<int>(nullable: true),
                    UnexpectedEntryExitDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    UnexpectedEntryExitDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    UnexpectedEntryExitDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_Period_Is24Hours = table.Column<bool>(nullable: true),
                    Details_Period_PeriodStartTime = table.Column<string>(nullable: true),
                    Details_Period_PeriodEndTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCSEvent_Id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EssenceEvent",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "Application");
        }
    }
}
