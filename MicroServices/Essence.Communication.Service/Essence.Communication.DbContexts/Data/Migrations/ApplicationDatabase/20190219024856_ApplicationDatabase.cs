using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Essence.Communication.DbContexts.Data.Migrations.ApplicationDatabase
{
    public partial class ApplicationDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Application");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AccountGroup",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    VendorId = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    VendorAccountNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Application",
                        principalTable: "AccountGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalSchema: "Application",
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EssenceEvent",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 2, 19, 2, 48, 56, 108, DateTimeKind.Utc).AddTicks(3941)),
                    VendorId = table.Column<string>(nullable: true),
                    Account = table.Column<int>(nullable: false),
                    Event_Code = table.Column<int>(nullable: false),
                    Event_Severity = table.Column<int>(nullable: false),
                    Event_Details = table.Column<string>(nullable: true),
                    Event_IsMobile = table.Column<bool>(nullable: true),
                    Event_Location_Latitude = table.Column<string>(nullable: true),
                    Event_Location_Longitude = table.Column<string>(nullable: true),
                    Event_Location_HorizontalAccuracy = table.Column<int>(nullable: true),
                    PanelTime = table.Column<string>(nullable: true),
                    ServerTime = table.Column<string>(nullable: true),
                    ServiceProvider = table.Column<int>(nullable: true),
                    ServiceType = table.Column<int>(nullable: true),
                    Ids = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssenceEvent_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EssenceEvent_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalSchema: "Application",
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserType = table.Column<string>(nullable: true),
                    CellPhoneNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    VendorId = table.Column<string>(nullable: true),
                    VendorUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalSchema: "Application",
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    AccountId = table.Column<string>(nullable: true),
                    AlertType = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    PanelTime = table.Column<string>(nullable: true),
                    ServiceProvider = table.Column<int>(nullable: true),
                    ServerTime = table.Column<string>(nullable: true),
                    IsMobile = table.Column<bool>(nullable: true),
                    VendorEventId = table.Column<string>(nullable: true),
                    HSCCode = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    HorizontalAccuracy = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Details_DeviceId = table.Column<int>(nullable: true),
                    Details_DeviceType = table.Column<int>(nullable: true),
                    Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_BatteryLevel = table.Column<int>(nullable: true),
                    EmergencyPanicDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    EmergencyPanicDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    EmergencyPanicDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    FallAlertDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    FallAlertDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    FallAlertDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_Activitytype = table.Column<int>(nullable: true),
                    Details_DurationInRoom = table.Column<string>(nullable: true),
                    Details_LastContactTime = table.Column<string>(nullable: true),
                    PowerDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    PowerDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    PowerDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_PowerFailureDuration = table.Column<string>(nullable: true),
                    Details_PowerRestoredDuration = table.Column<string>(nullable: true),
                    Details_ExitTime = table.Column<string>(nullable: true),
                    Details_PeriodStartTime = table.Column<string>(nullable: true),
                    Details_PeriodEndTime = table.Column<string>(nullable: true),
                    Details_MaximumOutOfHomeDuration = table.Column<string>(nullable: true),
                    Details_EntryTime = table.Column<string>(nullable: true),
                    UnexpectedActivityDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    UnexpectedActivityDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    UnexpectedActivityDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_Grade = table.Column<float>(nullable: true),
                    UnexpectedEntryExitDetails_Details_DeviceId = table.Column<int>(nullable: true),
                    UnexpectedEntryExitDetails_Details_DeviceType = table.Column<int>(nullable: true),
                    UnexpectedEntryExitDetails_Details_DeviceDescription = table.Column<string>(nullable: true),
                    Details_Period_Is24Hours = table.Column<bool>(nullable: true),
                    Details_Period_PeriodStartTime = table.Column<string>(nullable: true),
                    Details_Period_PeriodEndTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCSEvent_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Application",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountUser",
                schema: "Application",
                columns: table => new
                {
                    AccountId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_AccountUser_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Account_GroupId",
                schema: "Application",
                table: "Account",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_VendorId",
                schema: "Application",
                table: "Account",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_UserId",
                schema: "Application",
                table: "AccountUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EssenceEvent_VendorId",
                schema: "Application",
                table: "EssenceEvent",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_AccountId",
                schema: "Application",
                table: "Event",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                schema: "Identity",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_VendorId",
                schema: "Identity",
                table: "User",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "Identity",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                schema: "Identity",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                schema: "Identity",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUser",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "EssenceEvent",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AccountGroup",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "Application");
        }
    }
}
