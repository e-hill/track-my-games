using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class AddCounterToGoalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Goals",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Earned",
                table: "Goals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Goals",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Earned",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Goals");
        }
    }
}
