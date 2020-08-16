using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class RenameCompletedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Games");

            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                table: "Games",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complete",
                table: "Games");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Games",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
