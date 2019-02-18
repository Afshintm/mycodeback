using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class AddVendorAccountIdInAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 11, 23, 33, 57, 645, DateTimeKind.Utc).AddTicks(9915),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 11, 12, 39, 53, 788, DateTimeKind.Utc).AddTicks(1587));

            migrationBuilder.AddColumn<string>(
                name: "VendorAccountId",
                schema: "Application",
                table: "Account",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorAccountId",
                schema: "Application",
                table: "Account");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 11, 12, 39, 53, 788, DateTimeKind.Utc).AddTicks(1587),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 11, 23, 33, 57, 645, DateTimeKind.Utc).AddTicks(9915));
        }
    }
}
