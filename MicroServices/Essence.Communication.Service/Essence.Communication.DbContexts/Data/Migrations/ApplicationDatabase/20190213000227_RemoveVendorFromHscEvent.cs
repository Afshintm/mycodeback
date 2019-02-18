using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class RemoveVendorFromHscEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Vendors_VendorId",
                schema: "Application",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_VendorId",
                schema: "Application",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VendorId",
                schema: "Application",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvents",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 13, 0, 2, 26, 573, DateTimeKind.Utc).AddTicks(3571),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 12, 3, 22, 2, 476, DateTimeKind.Utc).AddTicks(2375));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VendorId",
                schema: "Application",
                table: "Events",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvents",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 12, 3, 22, 2, 476, DateTimeKind.Utc).AddTicks(2375),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 13, 0, 2, 26, 573, DateTimeKind.Utc).AddTicks(3571));

            migrationBuilder.CreateIndex(
                name: "IX_Events_VendorId",
                schema: "Application",
                table: "Events",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Vendors_VendorId",
                schema: "Application",
                table: "Events",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
