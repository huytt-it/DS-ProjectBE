using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CreateDateTime = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    PublicKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Layout",
                columns: table => new
                {
                    LayoutID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    isHorizontal = table.Column<bool>(nullable: false),
                    LayoutSrc = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    isPublic = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layout", x => x.LayoutID);
                });

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    PlaylistID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BrandID = table.Column<int>(nullable: false),
                    isPublic = table.Column<bool>(nullable: true),
                    VisualTypeID = table.Column<int>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.PlaylistID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    SlotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    TimeSlotFilterBinary = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.SlotID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    BrandID = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEndDateUtc = table.Column<DateTime>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Brand",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandID = table.Column<int>(nullable: false),
                    Province = table.Column<string>(maxLength: 50, nullable: true),
                    District = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 150, nullable: false),
                    CreateDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Location_Brand",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resolution",
                columns: table => new
                {
                    ResolutionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    BrandID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolution", x => x.ResolutionID);
                    table.ForeignKey(
                        name: "FK_Resolution_Brand",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutID = table.Column<int>(nullable: false),
                    VisualTypeID = table.Column<int>(nullable: true),
                    Scale = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    WidthPercent = table.Column<decimal>(type: "decimal(10, 2)", nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Height = table.Column<double>(nullable: true),
                    Width = table.Column<double>(nullable: true),
                    X = table.Column<double>(nullable: true),
                    Y = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaID);
                    table.ForeignKey(
                        name: "FK_Area_Layout",
                        column: x => x.LayoutID,
                        principalTable: "Layout",
                        principalColumn: "LayoutID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scenario",
                columns: table => new
                {
                    ScenarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    BrandID = table.Column<int>(nullable: false),
                    isPublic = table.Column<bool>(nullable: true),
                    AudioArea = table.Column<int>(nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenario", x => new { x.ScenarioID, x.LayoutID });
                    table.ForeignKey(
                        name: "FK_Scenario_Brand",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenario_Layout",
                        column: x => x.LayoutID,
                        principalTable: "Layout",
                        principalColumn: "LayoutID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaSrc",
                columns: table => new
                {
                    MediaSrcID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    isPublic = table.Column<bool>(nullable: true),
                    TypeID = table.Column<int>(nullable: false),
                    URL = table.Column<string>(nullable: false),
                    UpdateDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDatetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    SecurityHash = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaSrc", x => x.MediaSrcID);
                    table.ForeignKey(
                        name: "FK_MediaSrc_Brand",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaSrc_MediaType",
                        column: x => x.TypeID,
                        principalTable: "MediaType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(maxLength: 128, nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    UserId = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey, x.UserId });
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 128, nullable: false),
                    RoleId = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    DeviceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDatetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    BrandID = table.Column<int>(nullable: true),
                    MatchingCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    LocationID = table.Column<int>(nullable: true),
                    BoxName = table.Column<string>(nullable: true),
                    ScreenName = table.Column<string>(maxLength: 50, nullable: true),
                    isHorizontal = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.DeviceID);
                    table.ForeignKey(
                        name: "FK_Device_Location",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScenarioItem",
                columns: table => new
                {
                    PlaylistID = table.Column<int>(nullable: false),
                    ScenarioID = table.Column<int>(nullable: false),
                    AreaID = table.Column<int>(nullable: false),
                    LayoutID = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScenarioItem", x => new { x.PlaylistID, x.ScenarioID, x.AreaID, x.LayoutID });
                    table.ForeignKey(
                        name: "FK_PlaylistScenarioArea_Playlist",
                        column: x => x.PlaylistID,
                        principalTable: "Playlist",
                        principalColumn: "PlaylistID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScenarioItem_Scenario",
                        columns: x => new { x.ScenarioID, x.LayoutID },
                        principalTable: "Scenario",
                        principalColumns: new[] { "ScenarioID", "LayoutID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistItem",
                columns: table => new
                {
                    PlaylistItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaSrcID = table.Column<int>(nullable: false),
                    PlaylistID = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistItem", x => x.PlaylistItemID);
                    table.ForeignKey(
                        name: "FK_PlaylistItem_MediaSrc",
                        column: x => x.MediaSrcID,
                        principalTable: "MediaSrc",
                        principalColumn: "MediaSrcID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistItem_Playlist",
                        column: x => x.PlaylistID,
                        principalTable: "Playlist",
                        principalColumn: "PlaylistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceScenario",
                columns: table => new
                {
                    DeviceScenationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceID = table.Column<int>(nullable: false),
                    ScenarioID = table.Column<int>(nullable: false),
                    TimesToPlay = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    LayoutID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceScenario", x => x.DeviceScenationID);
                    table.ForeignKey(
                        name: "FK_DeviceScenario_Device",
                        column: x => x.DeviceID,
                        principalTable: "Device",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceScenario_Scenario",
                        columns: x => new { x.ScenarioID, x.LayoutID },
                        principalTable: "Scenario",
                        principalColumns: new[] { "ScenarioID", "LayoutID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistReport",
                columns: table => new
                {
                    PlaylistID = table.Column<int>(nullable: false),
                    DeviceID = table.Column<int>(nullable: false),
                    PlaylistTitle = table.Column<string>(maxLength: 150, nullable: true),
                    PlaylistDesc = table.Column<string>(nullable: true),
                    PlayedTimeCount = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    BrandID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistReport_1", x => new { x.PlaylistID, x.DeviceID });
                    table.ForeignKey(
                        name: "FK_PlaylistReport_Device",
                        column: x => x.DeviceID,
                        principalTable: "Device",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistReport_Location",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceID = table.Column<int>(nullable: false),
                    ScenarioID = table.Column<int>(nullable: false),
                    LayoutID = table.Column<int>(nullable: false),
                    TimeFilter = table.Column<int>(nullable: false),
                    DayFilter = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    isEnable = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_Schedule_Device",
                        column: x => x.DeviceID,
                        principalTable: "Device",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_Scenario",
                        columns: x => new { x.ScenarioID, x.LayoutID },
                        principalTable: "Scenario",
                        principalColumns: new[] { "ScenarioID", "LayoutID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_LayoutID",
                table: "Area",
                column: "LayoutID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BrandID",
                table: "AspNetUsers",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Device_LocationID",
                table: "Device",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceScenario_DeviceID",
                table: "DeviceScenario",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceScenario_ScenarioID_LayoutID",
                table: "DeviceScenario",
                columns: new[] { "ScenarioID", "LayoutID" });

            migrationBuilder.CreateIndex(
                name: "IX_Location_BrandID",
                table: "Location",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaSrc_BrandID",
                table: "MediaSrc",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaSrc_TypeID",
                table: "MediaSrc",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItem_PlaylistID",
                table: "PlaylistItem",
                column: "PlaylistID");

            migrationBuilder.CreateIndex(
                name: "UK_PlaylistItem",
                table: "PlaylistItem",
                columns: new[] { "MediaSrcID", "PlaylistID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistReport_DeviceID",
                table: "PlaylistReport",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistReport_LocationID",
                table: "PlaylistReport",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Resolution_BrandID",
                table: "Resolution",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenario_BrandID",
                table: "Scenario",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenario_LayoutID",
                table: "Scenario",
                column: "LayoutID");

            migrationBuilder.CreateIndex(
                name: "IX_ScenarioItem_ScenarioID_LayoutID",
                table: "ScenarioItem",
                columns: new[] { "ScenarioID", "LayoutID" });

            migrationBuilder.CreateIndex(
                name: "UK_ScenarioItem",
                table: "ScenarioItem",
                columns: new[] { "AreaID", "ScenarioID", "PlaylistID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_DeviceID",
                table: "Schedule",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ScenarioID_LayoutID",
                table: "Schedule",
                columns: new[] { "ScenarioID", "LayoutID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "DeviceScenario");

            migrationBuilder.DropTable(
                name: "PlaylistItem");

            migrationBuilder.DropTable(
                name: "PlaylistReport");

            migrationBuilder.DropTable(
                name: "Resolution");

            migrationBuilder.DropTable(
                name: "ScenarioItem");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MediaSrc");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Scenario");

            migrationBuilder.DropTable(
                name: "MediaType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Layout");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
