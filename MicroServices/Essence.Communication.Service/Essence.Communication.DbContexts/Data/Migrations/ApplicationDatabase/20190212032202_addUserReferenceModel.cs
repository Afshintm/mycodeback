using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class addUserReferenceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_AccountUser_Account_AccountId",
                schema: "Application",
                table: "AccountUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountUser_ApplicationUser_UserId",
                schema: "Application",
                table: "AccountUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EssenceEvent_Vendor_VendorId",
                schema: "Application",
                table: "EssenceEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Account_AccountId",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Vendor_VendorId",
                schema: "Application",
                table: "Event");

            migrationBuilder.DropTable(
                name: "ApplicationUser",
                schema: "Application");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                schema: "Application",
                table: "Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountUser",
                schema: "Application",
                table: "AccountUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountGroup",
                schema: "Application",
                table: "AccountGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                schema: "Application",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Vendor",
                schema: "Application",
                newName: "Vendors",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "Event",
                schema: "Application",
                newName: "Events",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "EssenceEvent",
                schema: "Application",
                newName: "EssenceEvents",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "AccountUser",
                schema: "Application",
                newName: "AccountUsers",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "AccountGroup",
                schema: "Application",
                newName: "AccountGroups",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "Application",
                newName: "Accounts",
                newSchema: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Event_VendorId",
                schema: "Application",
                table: "Events",
                newName: "IX_Events_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_AccountId",
                schema: "Application",
                table: "Events",
                newName: "IX_Events_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_EssenceEvent_VendorId",
                schema: "Application",
                table: "EssenceEvents",
                newName: "IX_EssenceEvents_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountUser_UserId",
                schema: "Application",
                table: "AccountUsers",
                newName: "IX_AccountUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_VendorId",
                schema: "Application",
                table: "Accounts",
                newName: "IX_Accounts_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_GroupId",
                schema: "Application",
                table: "Accounts",
                newName: "IX_Accounts_GroupId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvents",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 12, 3, 22, 2, 476, DateTimeKind.Utc).AddTicks(2375),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 11, 23, 33, 57, 645, DateTimeKind.Utc).AddTicks(9915));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                schema: "Application",
                table: "Vendors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountUsers",
                schema: "Application",
                table: "AccountUsers",
                columns: new[] { "AccountId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountGroups",
                schema: "Application",
                table: "AccountGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                schema: "Application",
                table: "Accounts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountGroups_GroupId",
                schema: "Application",
                table: "Accounts",
                column: "GroupId",
                principalSchema: "Application",
                principalTable: "AccountGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Vendors_VendorId",
                schema: "Application",
                table: "Accounts",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUsers_Accounts_AccountId",
                schema: "Application",
                table: "AccountUsers",
                column: "AccountId",
                principalSchema: "Application",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUsers_Users_UserId",
                schema: "Application",
                table: "AccountUsers",
                column: "UserId",
                principalSchema: "Application",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EssenceEvents_Vendors_VendorId",
                schema: "Application",
                table: "EssenceEvents",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Accounts_AccountId",
                schema: "Application",
                table: "Events",
                column: "AccountId",
                principalSchema: "Application",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AccountGroups_GroupId",
                schema: "Application",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Vendors_VendorId",
                schema: "Application",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountUsers_Accounts_AccountId",
                schema: "Application",
                table: "AccountUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountUsers_Users_UserId",
                schema: "Application",
                table: "AccountUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EssenceEvents_Vendors_VendorId",
                schema: "Application",
                table: "EssenceEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Accounts_AccountId",
                schema: "Application",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Vendors_VendorId",
                schema: "Application",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Application");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                schema: "Application",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountUsers",
                schema: "Application",
                table: "AccountUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                schema: "Application",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountGroups",
                schema: "Application",
                table: "AccountGroups");

            migrationBuilder.RenameTable(
                name: "Vendors",
                schema: "Application",
                newName: "Vendor",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "Events",
                schema: "Application",
                newName: "Event",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "EssenceEvents",
                schema: "Application",
                newName: "EssenceEvent",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "AccountUsers",
                schema: "Application",
                newName: "AccountUser",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "Accounts",
                schema: "Application",
                newName: "Account",
                newSchema: "Application");

            migrationBuilder.RenameTable(
                name: "AccountGroups",
                schema: "Application",
                newName: "AccountGroup",
                newSchema: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_Events_VendorId",
                schema: "Application",
                table: "Event",
                newName: "IX_Event_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_AccountId",
                schema: "Application",
                table: "Event",
                newName: "IX_Event_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_EssenceEvents_VendorId",
                schema: "Application",
                table: "EssenceEvent",
                newName: "IX_EssenceEvent_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountUsers_UserId",
                schema: "Application",
                table: "AccountUser",
                newName: "IX_AccountUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_VendorId",
                schema: "Application",
                table: "Account",
                newName: "IX_Account_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_GroupId",
                schema: "Application",
                table: "Account",
                newName: "IX_Account_GroupId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                schema: "Application",
                table: "EssenceEvent",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 11, 23, 33, 57, 645, DateTimeKind.Utc).AddTicks(9915),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 12, 3, 22, 2, 476, DateTimeKind.Utc).AddTicks(2375));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                schema: "Application",
                table: "Vendor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountUser",
                schema: "Application",
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                schema: "Application",
                table: "Account",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountGroup",
                schema: "Application",
                table: "AccountGroup",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

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
                name: "FK_AccountUser_Account_AccountId",
                schema: "Application",
                table: "AccountUser",
                column: "AccountId",
                principalSchema: "Application",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUser_ApplicationUser_UserId",
                schema: "Application",
                table: "AccountUser",
                column: "UserId",
                principalSchema: "Application",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EssenceEvent_Vendor_VendorId",
                schema: "Application",
                table: "EssenceEvent",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Account_AccountId",
                schema: "Application",
                table: "Event",
                column: "AccountId",
                principalSchema: "Application",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Vendor_VendorId",
                schema: "Application",
                table: "Event",
                column: "VendorId",
                principalSchema: "Application",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
