using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class AddVendorToUserRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvents");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "Application",
                table: "Vendors",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "Application",
                table: "Events",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "Application",
                table: "AccountUsers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "Application",
                table: "Accounts",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "Application",
                table: "AccountGroups",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "VendorId",
                schema: "Application",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorUserId",
                schema: "Application",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "Application",
                table: "EssenceEvents",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 13, 6, 42, 22, 171, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.CreateIndex(
                name: "IX_Users_VendorId",
                schema: "Application",
                table: "Users",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Vendors_VendorId",
                schema: "Application",
                table: "Users",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Vendors_VendorId",
                schema: "Application",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VendorId",
                schema: "Application",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VendorId",
                schema: "Application",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VendorUserId",
                schema: "Application",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "Application",
                table: "EssenceEvents");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "Application",
                table: "Vendors",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "Application",
                table: "Events",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "Application",
                table: "AccountUsers",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "Application",
                table: "Accounts",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "Application",
                table: "AccountGroups",
                newName: "CreateDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvents",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 13, 0, 2, 26, 573, DateTimeKind.Utc).AddTicks(3571));
        }
    }
}
