using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class MakeCollectionFKOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophyCollections_Games_GameId",
                table: "PsnTrophyCollections");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "PsnTrophyCollections",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophyCollections_Games_GameId",
                table: "PsnTrophyCollections",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophyCollections_Games_GameId",
                table: "PsnTrophyCollections");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "PsnTrophyCollections",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophyCollections_Games_GameId",
                table: "PsnTrophyCollections",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
