using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class ApplicationDa22tabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Application",
                table: "AccountGroup",
                keyColumn: "Id",
                keyValue: "d74f7d33-bba8-47df-8eb5-da8002c25954");

            migrationBuilder.DeleteData(
                schema: "Application",
                table: "Vendor",
                keyColumn: "Id",
                keyValue: "5bfde310-977f-4ca9-9e54-4312834d27b0");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 19, 3, 13, 9, 737, DateTimeKind.Utc).AddTicks(6603),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 19, 2, 48, 56, 108, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.InsertData(
                schema: "Application",
                table: "AccountGroup",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { "6d1b3ab8-183f-453a-8e2e-e6b200006138", new DateTime(2019, 2, 19, 3, 13, 9, 780, DateTimeKind.Utc).AddTicks(1878), "TestGroup" });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "Vendor",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { "6dcbe9e4-c0a1-4658-ba38-85f78615985f", new DateTime(2019, 2, 19, 3, 13, 9, 778, DateTimeKind.Utc).AddTicks(5098), "Essence" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Application",
                table: "AccountGroup",
                keyColumn: "Id",
                keyValue: "6d1b3ab8-183f-453a-8e2e-e6b200006138");

            migrationBuilder.DeleteData(
                schema: "Application",
                table: "Vendor",
                keyColumn: "Id",
                keyValue: "6dcbe9e4-c0a1-4658-ba38-85f78615985f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 19, 2, 48, 56, 108, DateTimeKind.Utc).AddTicks(3941),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 19, 3, 13, 9, 737, DateTimeKind.Utc).AddTicks(6603));

            migrationBuilder.InsertData(
                schema: "Application",
                table: "AccountGroup",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { "d74f7d33-bba8-47df-8eb5-da8002c25954", new DateTime(2019, 2, 19, 2, 48, 56, 150, DateTimeKind.Utc).AddTicks(7586), "TestGroup" });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "Vendor",
                columns: new[] { "Id", "CreatedDate", "Name" },
                values: new object[] { "5bfde310-977f-4ca9-9e54-4312834d27b0", new DateTime(2019, 2, 19, 2, 48, 56, 149, DateTimeKind.Utc).AddTicks(3102), "Essence" });
        }
    }
}
