using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class AddHscAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Vendor",
                nullable: false,
                defaultValue: "0caf25c3-6b65-4bd7-bb2f-d8599bbe72b3",
                oldClrType: typeof(string),
                oldDefaultValue: "4c3ddd57-7eb3-4c21-bc43-fd61b65de8fe");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 7, 13, 23, 38, 461, DateTimeKind.Utc).AddTicks(3357),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 7, 12, 53, 32, 96, DateTimeKind.Utc).AddTicks(4492));

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                schema: "Application",
                table: "Event",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "2fb6520a-acb6-4cf9-944b-54839a791ae9",
                oldClrType: typeof(string),
                oldDefaultValue: "fd6a99ee-da09-47aa-a74e-cc9ece3ba801");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 7, 13, 23, 38, 505, DateTimeKind.Utc).AddTicks(8858),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 7, 12, 53, 32, 133, DateTimeKind.Utc).AddTicks(6061));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "9e6abf45-5f91-4d1d-a7fe-95340c145035",
                oldClrType: typeof(string),
                oldDefaultValue: "ce4becbc-22d2-44ac-be36-8042243e09aa");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, defaultValue: "675fd40b-2855-4907-8ea9-d4db23bc27ab"),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_AccountId",
                schema: "Application",
                table: "Event",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Account_AccountId",
                schema: "Application",
                table: "Event",
                column: "AccountId",
                principalSchema: "Application",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Account_AccountId",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Event_AccountId",
                schema: "Application",
                table: "Event");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Vendor",
                nullable: false,
                defaultValue: "4c3ddd57-7eb3-4c21-bc43-fd61b65de8fe",
                oldClrType: typeof(string),
                oldDefaultValue: "0caf25c3-6b65-4bd7-bb2f-d8599bbe72b3");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 7, 12, 53, 32, 96, DateTimeKind.Utc).AddTicks(4492),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 7, 13, 23, 38, 461, DateTimeKind.Utc).AddTicks(3357));

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                schema: "Application",
                table: "Event",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "fd6a99ee-da09-47aa-a74e-cc9ece3ba801",
                oldClrType: typeof(string),
                oldDefaultValue: "2fb6520a-acb6-4cf9-944b-54839a791ae9");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 7, 12, 53, 32, 133, DateTimeKind.Utc).AddTicks(6061),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 7, 13, 23, 38, 505, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "ce4becbc-22d2-44ac-be36-8042243e09aa",
                oldClrType: typeof(string),
                oldDefaultValue: "9e6abf45-5f91-4d1d-a7fe-95340c145035");
        }
    }
}
