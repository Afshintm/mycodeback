using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class AddIdListInEssenceEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 31, 6, 41, 59, 336, DateTimeKind.Utc).AddTicks(6192),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 30, 6, 23, 1, 568, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "762135b4-4ba6-4b8d-aa89-16349cc4be38",
                oldClrType: typeof(string),
                oldDefaultValue: "85e44370-293b-496e-b765-d2c9230045a3");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 31, 6, 41, 59, 368, DateTimeKind.Utc).AddTicks(7137),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 30, 6, 23, 1, 580, DateTimeKind.Utc).AddTicks(1471));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "314049d3-76bf-4873-8495-9ce35317c102",
                oldClrType: typeof(string),
                oldDefaultValue: "d1f7b951-243a-41a0-9549-9a040cbbaf1a");

            migrationBuilder.AddColumn<string>(
                name: "Ids",
                schema: "Application",
                table: "EssenceEvent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ids",
                schema: "Application",
                table: "EssenceEvent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 30, 6, 23, 1, 568, DateTimeKind.Utc).AddTicks(105),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 31, 6, 41, 59, 336, DateTimeKind.Utc).AddTicks(6192));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "85e44370-293b-496e-b765-d2c9230045a3",
                oldClrType: typeof(string),
                oldDefaultValue: "762135b4-4ba6-4b8d-aa89-16349cc4be38");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 30, 6, 23, 1, 580, DateTimeKind.Utc).AddTicks(1471),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 31, 6, 41, 59, 368, DateTimeKind.Utc).AddTicks(7137));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "d1f7b951-243a-41a0-9549-9a040cbbaf1a",
                oldClrType: typeof(string),
                oldDefaultValue: "314049d3-76bf-4873-8495-9ce35317c102");
        }
    }
}
