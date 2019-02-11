using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class RemoveDefaultGuidId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Vendor",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "55de6a96-78ab-416c-b847-cfae00dcd712");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "9f95de6a-92c0-44f4-98ea-f6a0977d235c");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 11, 12, 39, 53, 788, DateTimeKind.Utc).AddTicks(1587),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 11, 12, 6, 54, 761, DateTimeKind.Utc).AddTicks(776));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "004e6480-cdde-4576-ac5e-72b773a4832f");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Account",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "20f8122d-1573-46b4-994a-35f2f561919f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Vendor",
                nullable: false,
                defaultValue: "55de6a96-78ab-416c-b847-cfae00dcd712",
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "9f95de6a-92c0-44f4-98ea-f6a0977d235c",
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 11, 12, 6, 54, 761, DateTimeKind.Utc).AddTicks(776),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 11, 12, 39, 53, 788, DateTimeKind.Utc).AddTicks(1587));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "004e6480-cdde-4576-ac5e-72b773a4832f",
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Account",
                nullable: false,
                defaultValue: "20f8122d-1573-46b4-994a-35f2f561919f",
                oldClrType: typeof(string));
        }
    }
}
