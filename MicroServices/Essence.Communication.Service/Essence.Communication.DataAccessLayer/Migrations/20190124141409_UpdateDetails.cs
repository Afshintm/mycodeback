using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DataAccessLayer.Migrations
{
    public partial class UpdateDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Details_Grade",
                schema: "Application",
                table: "Event",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 14, 14, 9, 13, DateTimeKind.Utc).AddTicks(2341),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 10, 21, 52, 885, DateTimeKind.Utc).AddTicks(3521));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "bd6b6c27-aea7-4d9a-8ec8-dba53126cb73",
                oldClrType: typeof(string),
                oldDefaultValue: "dd480caa-1d0b-4b9f-8d78-66f06c492cc6");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 14, 14, 9, 43, DateTimeKind.Utc).AddTicks(9722),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 10, 21, 52, 922, DateTimeKind.Utc).AddTicks(1210));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "6106566b-4c61-4164-97f5-4d064a4e092f",
                oldClrType: typeof(string),
                oldDefaultValue: "4bbc48d2-6fe7-4a9e-851e-7da5882b76ed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Details_Grade",
                schema: "Application",
                table: "Event",
                nullable: true,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 10, 21, 52, 885, DateTimeKind.Utc).AddTicks(3521),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 14, 14, 9, 13, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "dd480caa-1d0b-4b9f-8d78-66f06c492cc6",
                oldClrType: typeof(string),
                oldDefaultValue: "bd6b6c27-aea7-4d9a-8ec8-dba53126cb73");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 10, 21, 52, 922, DateTimeKind.Utc).AddTicks(1210),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 14, 14, 9, 43, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "4bbc48d2-6fe7-4a9e-851e-7da5882b76ed",
                oldClrType: typeof(string),
                oldDefaultValue: "6106566b-4c61-4164-97f5-4d064a4e092f");
        }
    }
}
