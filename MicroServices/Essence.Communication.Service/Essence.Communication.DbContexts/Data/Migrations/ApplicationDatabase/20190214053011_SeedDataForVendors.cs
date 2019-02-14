using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class SeedDataForVendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendorAccountId",
                schema: "Application",
                table: "Accounts",
                newName: "VendorAccountNo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Application",
                table: "EssenceEvents",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 14, 5, 30, 10, 912, DateTimeKind.Utc).AddTicks(3603),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 13, 6, 42, 22, 171, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.AddColumn<string>(
                name: "AccountNo",
                schema: "Application",
                table: "Accounts",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "AccountNo",
                schema: "Application",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "VendorAccountNo",
                schema: "Application",
                table: "Accounts",
                newName: "VendorAccountId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Application",
                table: "EssenceEvents",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 13, 6, 42, 22, 171, DateTimeKind.Utc).AddTicks(1584),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 14, 5, 30, 10, 912, DateTimeKind.Utc).AddTicks(3603));
        }
    }
}
