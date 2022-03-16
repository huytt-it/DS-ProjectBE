using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddDSEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DSBuilding_DSUser_UserId",
                table: "DSBuilding");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "DSBuilding",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_DSBuilding_DSUser_UserId",
                table: "DSBuilding",
                column: "UserId",
                principalTable: "DSUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DSBuilding_DSUser_UserId",
                table: "DSBuilding");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "DSBuilding",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DSBuilding_DSUser_UserId",
                table: "DSBuilding",
                column: "UserId",
                principalTable: "DSUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
