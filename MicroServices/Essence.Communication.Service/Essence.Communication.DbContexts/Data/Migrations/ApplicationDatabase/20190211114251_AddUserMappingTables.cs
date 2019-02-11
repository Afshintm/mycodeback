using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class AddUserMappingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Vendor",
                nullable: false,
                defaultValue: "7e84949d-49a5-44b4-b103-e1d77944bc96",
                oldClrType: typeof(string),
                oldDefaultValue: "0caf25c3-6b65-4bd7-bb2f-d8599bbe72b3");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 7, 13, 23, 38, 461, DateTimeKind.Utc).AddTicks(3357));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "256edb43-c314-444f-844e-bfcc700701c1",
                oldClrType: typeof(string),
                oldDefaultValue: "2fb6520a-acb6-4cf9-944b-54839a791ae9");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 11, 11, 42, 51, 267, DateTimeKind.Utc).AddTicks(3954),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 7, 13, 23, 38, 505, DateTimeKind.Utc).AddTicks(8858));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "7d8c9539-7e63-4305-ac4c-0296d6a6cd92",
                oldClrType: typeof(string),
                oldDefaultValue: "9e6abf45-5f91-4d1d-a7fe-95340c145035");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Account",
                nullable: false,
                defaultValue: "84a9fe4e-3ef4-45fc-81ec-4d38398709d8",
                oldClrType: typeof(string),
                oldDefaultValue: "675fd40b-2855-4907-8ea9-d4db23bc27ab");

            migrationBuilder.AddColumn<string>(
                name: "AccountGroupId",
                schema: "Application",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountGroup",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountUser",
                schema: "Application",
                columns: table => new
                {
                    AccountId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUser", x => new { x.AccountId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AccountUser_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Application",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountGroupId",
                schema: "Application",
                table: "Account",
                column: "AccountGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AccountGroup_AccountGroupId",
                schema: "Application",
                table: "Account",
                column: "AccountGroupId",
                principalSchema: "Application",
                principalTable: "AccountGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AccountGroup_AccountGroupId",
                schema: "Application",
                table: "Account");

            migrationBuilder.DropTable(
                name: "AccountGroup",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "AccountUser",
                schema: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Account_AccountGroupId",
                schema: "Application",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "AccountGroupId",
                schema: "Application",
                table: "Account");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Vendor",
                nullable: false,
                defaultValue: "0caf25c3-6b65-4bd7-bb2f-d8599bbe72b3",
                oldClrType: typeof(string),
                oldDefaultValue: "7e84949d-49a5-44b4-b103-e1d77944bc96");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 7, 13, 23, 38, 461, DateTimeKind.Utc).AddTicks(3357),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "2fb6520a-acb6-4cf9-944b-54839a791ae9",
                oldClrType: typeof(string),
                oldDefaultValue: "256edb43-c314-444f-844e-bfcc700701c1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 7, 13, 23, 38, 505, DateTimeKind.Utc).AddTicks(8858),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 11, 11, 42, 51, 267, DateTimeKind.Utc).AddTicks(3954));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "9e6abf45-5f91-4d1d-a7fe-95340c145035",
                oldClrType: typeof(string),
                oldDefaultValue: "7d8c9539-7e63-4305-ac4c-0296d6a6cd92");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Account",
                nullable: false,
                defaultValue: "675fd40b-2855-4907-8ea9-d4db23bc27ab",
                oldClrType: typeof(string),
                oldDefaultValue: "84a9fe4e-3ef4-45fc-81ec-4d38398709d8");
        }
    }
}
