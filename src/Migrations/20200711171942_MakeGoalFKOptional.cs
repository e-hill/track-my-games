using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class MakeGoalFKOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Games_GameId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GameSeries",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Games_GameId",
                table: "Goals",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Games_GameId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GameSeries");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Goals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Games_GameId",
                table: "Goals",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
