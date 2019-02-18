using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class RefVendoToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AccountGroup_AccountGroupId",
                schema: "Application",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountGroupId",
                schema: "Application",
                table: "Account",
                newName: "VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_AccountGroupId",
                schema: "Application",
                table: "Account",
                newName: "IX_Account_VendorId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Vendor",
                nullable: false,
                defaultValue: "55de6a96-78ab-416c-b847-cfae00dcd712",
                oldClrType: typeof(string),
                oldDefaultValue: "7e84949d-49a5-44b4-b103-e1d77944bc96");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "9f95de6a-92c0-44f4-98ea-f6a0977d235c",
                oldClrType: typeof(string),
                oldDefaultValue: "256edb43-c314-444f-844e-bfcc700701c1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 11, 12, 6, 54, 761, DateTimeKind.Utc).AddTicks(776),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 11, 11, 42, 51, 267, DateTimeKind.Utc).AddTicks(3954));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "004e6480-cdde-4576-ac5e-72b773a4832f",
                oldClrType: typeof(string),
                oldDefaultValue: "7d8c9539-7e63-4305-ac4c-0296d6a6cd92");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Account",
                nullable: false,
                defaultValue: "20f8122d-1573-46b4-994a-35f2f561919f",
                oldClrType: typeof(string),
                oldDefaultValue: "84a9fe4e-3ef4-45fc-81ec-4d38398709d8");

            migrationBuilder.AddColumn<string>(
                name: "GroupId",
                schema: "Application",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_UserId",
                schema: "Application",
                table: "AccountUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_GroupId",
                schema: "Application",
                table: "Account",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AccountGroup_GroupId",
                schema: "Application",
                table: "Account",
                column: "GroupId",
                principalSchema: "Application",
                principalTable: "AccountGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Vendor_VendorId",
                schema: "Application",
                table: "Account",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUser_ApplicationUser_UserId",
                schema: "Application",
                table: "AccountUser",
                column: "UserId",
                principalSchema: "Application",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AccountGroup_GroupId",
                schema: "Application",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Vendor_VendorId",
                schema: "Application",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountUser_ApplicationUser_UserId",
                schema: "Application",
                table: "AccountUser");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "Application");

            migrationBuilder.DropIndex(
                name: "IX_AccountUser_UserId",
                schema: "Application",
                table: "AccountUser");

            migrationBuilder.DropIndex(
                name: "IX_Account_GroupId",
                schema: "Application",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "Application",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                schema: "Application",
                table: "Account",
                newName: "AccountGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_VendorId",
                schema: "Application",
                table: "Account",
                newName: "IX_Account_AccountGroupId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Vendor",
                nullable: false,
                defaultValue: "7e84949d-49a5-44b4-b103-e1d77944bc96",
                oldClrType: typeof(string),
                oldDefaultValue: "55de6a96-78ab-416c-b847-cfae00dcd712");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Event",
                nullable: false,
                defaultValue: "256edb43-c314-444f-844e-bfcc700701c1",
                oldClrType: typeof(string),
                oldDefaultValue: "9f95de6a-92c0-44f4-98ea-f6a0977d235c");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 11, 11, 42, 51, 267, DateTimeKind.Utc).AddTicks(3954),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 11, 12, 6, 54, 761, DateTimeKind.Utc).AddTicks(776));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: "7d8c9539-7e63-4305-ac4c-0296d6a6cd92",
                oldClrType: typeof(string),
                oldDefaultValue: "004e6480-cdde-4576-ac5e-72b773a4832f");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                schema: "Application",
                table: "Account",
                nullable: false,
                defaultValue: "84a9fe4e-3ef4-45fc-81ec-4d38398709d8",
                oldClrType: typeof(string),
                oldDefaultValue: "20f8122d-1573-46b4-994a-35f2f561919f");

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
    }
}
