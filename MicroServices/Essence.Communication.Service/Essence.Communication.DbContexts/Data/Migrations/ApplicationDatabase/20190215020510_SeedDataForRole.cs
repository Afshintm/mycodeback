using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class SeedDataForRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountUsers_Accounts_AccountId",
                schema: "Application",
                table: "AccountUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountUsers_Users_UserId",
                schema: "Application",
                table: "AccountUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EssenceEvents_Vendors_VendorId",
                schema: "Application",
                table: "EssenceEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Accounts_AccountId",
                schema: "Application",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountUsers",
                schema: "Application",
                table: "AccountUsers");

            migrationBuilder.DeleteData(
                schema: "Application",
                table: "AccountGroups",
                keyColumn: "Id",
                keyValue: "422cddc9-8363-44fd-98b0-01c685a923f4");

            migrationBuilder.DeleteData(
                schema: "Application",
                table: "Vendors",
                keyColumn: "Id",
                keyValue: "21268423-2d32-417e-9c3b-bd7ad607834d");

            migrationBuilder.RenameTable(
                name: "Events",
                schema: "Application",
                newName: "Event",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "EssenceEvents",
                schema: "Application",
                newName: "EssenceEvent",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "AccountUsers",
                schema: "Application",
                newName: "AccountUser",
                newSchema: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Events_AccountId",
                schema: "Application",
                table: "Event",
                newName: "IX_Event_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_EssenceEvents_VendorId",
                schema: "Application",
                table: "EssenceEvent",
                newName: "IX_EssenceEvent_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountUsers_UserId",
                schema: "Application",
                table: "AccountUser",
                newName: "IX_AccountUser_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 15, 2, 5, 10, 363, DateTimeKind.Utc).AddTicks(6570),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 14, 5, 30, 10, 912, DateTimeKind.Utc).AddTicks(3603));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountUser",
                schema: "Application",
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "AccountGroups",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { "cf8509bb-df17-4c12-9ee4-bc1aa1ae8478", new DateTime(2019, 2, 15, 2, 5, 10, 406, DateTimeKind.Utc).AddTicks(6200), "TestGroup" });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "Vendors",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { "f472edd0-c556-45e7-974c-61cab7086ddf", new DateTime(2019, 2, 15, 2, 5, 10, 405, DateTimeKind.Utc).AddTicks(2515), "Essence" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUser_Accounts_AccountId",
                schema: "Application",
                table: "AccountUser",
                column: "AccountId",
                principalSchema: "Application",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUser_Users_UserId",
                schema: "Application",
                table: "AccountUser",
                column: "UserId",
                principalSchema: "Application",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EssenceEvent_Vendors_VendorId",
                schema: "Application",
                table: "EssenceEvent",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Accounts_AccountId",
                schema: "Application",
                table: "Event",
                column: "AccountId",
                principalSchema: "Application",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountUser_Accounts_AccountId",
                schema: "Application",
                table: "AccountUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountUser_Users_UserId",
                schema: "Application",
                table: "AccountUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EssenceEvent_Vendors_VendorId",
                schema: "Application",
                table: "EssenceEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Accounts_AccountId",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountUser",
                schema: "Application",
                table: "AccountUser");

            migrationBuilder.DeleteData(
                schema: "Application",
                table: "AccountGroups",
                keyColumn: "Id",
                keyValue: "cf8509bb-df17-4c12-9ee4-bc1aa1ae8478");

            migrationBuilder.DeleteData(
                schema: "Application",
                table: "Vendors",
                keyColumn: "Id",
                keyValue: "f472edd0-c556-45e7-974c-61cab7086ddf");

            migrationBuilder.RenameTable(
                name: "Event",
                schema: "Application",
                newName: "Events",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "EssenceEvent",
                schema: "Application",
                newName: "EssenceEvents",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "AccountUser",
                schema: "Application",
                newName: "AccountUsers",
                newSchema: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Event_AccountId",
                schema: "Application",
                table: "Events",
                newName: "IX_Events_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_EssenceEvent_VendorId",
                schema: "Application",
                table: "EssenceEvents",
                newName: "IX_EssenceEvents_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountUser_UserId",
                schema: "Application",
                table: "AccountUsers",
                newName: "IX_AccountUsers_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Application",
                table: "EssenceEvents",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 14, 5, 30, 10, 912, DateTimeKind.Utc).AddTicks(3603),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 15, 2, 5, 10, 363, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountUsers",
                schema: "Application",
                table: "AccountUsers",
                columns: new[] { "AccountId", "UserId" });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "AccountGroups",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { "422cddc9-8363-44fd-98b0-01c685a923f4", new DateTime(2019, 2, 14, 5, 30, 10, 955, DateTimeKind.Utc).AddTicks(2519), "TestGroup" });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "Vendors",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { "21268423-2d32-417e-9c3b-bd7ad607834d", new DateTime(2019, 2, 14, 5, 30, 10, 953, DateTimeKind.Utc).AddTicks(5318), "Essence" });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUsers_Accounts_AccountId",
                schema: "Application",
                table: "AccountUsers",
                column: "AccountId",
                principalSchema: "Application",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUsers_Users_UserId",
                schema: "Application",
                table: "AccountUsers",
                column: "UserId",
                principalSchema: "Application",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EssenceEvents_Vendors_VendorId",
                schema: "Application",
                table: "EssenceEvents",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Accounts_AccountId",
                schema: "Application",
                table: "Events",
                column: "AccountId",
                principalSchema: "Application",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
