using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class AddVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Severity",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "VendorType",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EmergencyLevel",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Vendor",
                schema: "Application",
                table: "EssenceEvent");

            migrationBuilder.RenameColumn(
                name: "UserID",
                schema: "Application",
                table: "Event",
                newName: "VendorId");

            migrationBuilder.RenameColumn(
                name: "EmergencyDescriptoin",
                schema: "Application",
                table: "Event",
                newName: "AccountId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 7, 12, 53, 32, 96, DateTimeKind.Utc).AddTicks(4492),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 31, 6, 41, 59, 336, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "fd6a99ee-da09-47aa-a74e-cc9ece3ba801",
                oldClrType: typeof(string),
                oldDefaultValue: "762135b4-4ba6-4b8d-aa89-16349cc4be38");

            migrationBuilder.AlterColumn<string>(
                name: "VendorId",
                schema: "Application",
                table: "Event",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlertType",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 7, 12, 53, 32, 133, DateTimeKind.Utc).AddTicks(6061),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 31, 6, 41, 59, 368, DateTimeKind.Utc).AddTicks(7137));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "ce4becbc-22d2-44ac-be36-8042243e09aa",
                oldClrType: typeof(string),
                oldDefaultValue: "314049d3-76bf-4873-8495-9ce35317c102");

            migrationBuilder.AddColumn<string>(
                name: "VendorId",
                schema: "Application",
                table: "EssenceEvent",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, defaultValue: "4c3ddd57-7eb3-4c21-bc43-fd61b65de8fe"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_VendorId",
                schema: "Application",
                table: "Event",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_EssenceEvent_VendorId",
                schema: "Application",
                table: "EssenceEvent",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EssenceEvent_Vendor_VendorId",
                schema: "Application",
                table: "EssenceEvent",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Vendor_VendorId",
                schema: "Application",
                table: "Event",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EssenceEvent_Vendor_VendorId",
                schema: "Application",
                table: "EssenceEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Vendor_VendorId",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Event_VendorId",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_EssenceEvent_VendorId",
                schema: "Application",
                table: "EssenceEvent");

            migrationBuilder.DropColumn(
                name: "AlertType",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "VendorId",
                schema: "Application",
                table: "EssenceEvent");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                schema: "Application",
                table: "Event",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                schema: "Application",
                table: "Event",
                newName: "EmergencyDescriptoin");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 31, 6, 41, 59, 336, DateTimeKind.Utc).AddTicks(6192),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 7, 12, 53, 32, 96, DateTimeKind.Utc).AddTicks(4492));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "762135b4-4ba6-4b8d-aa89-16349cc4be38",
                oldClrType: typeof(string),
                oldDefaultValue: "fd6a99ee-da09-47aa-a74e-cc9ece3ba801");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                schema: "Application",
                table: "Event",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Account",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceType",
                schema: "Application",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Severity",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VendorType",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmergencyLevel",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 31, 6, 41, 59, 368, DateTimeKind.Utc).AddTicks(7137),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 7, 12, 53, 32, 133, DateTimeKind.Utc).AddTicks(6061));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "314049d3-76bf-4873-8495-9ce35317c102",
                oldClrType: typeof(string),
                oldDefaultValue: "ce4becbc-22d2-44ac-be36-8042243e09aa");

            migrationBuilder.AddColumn<string>(
                name: "Vendor",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "");
        }
    }
}
