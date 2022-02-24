using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addIsDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "TimeSlot",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Schedule",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ScenarioItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Scenario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Resolution",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "PlaylistReport",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "PlaylistItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Playlist",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MediaType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "MediaSrc",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Location",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Layout",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "DeviceScenario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Device",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Brand",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Area",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "TimeSlot");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ScenarioItem");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Scenario");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Resolution");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "PlaylistReport");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "PlaylistItem");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MediaType");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "MediaSrc");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "DeviceScenario");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Area");
        }
    }
}
