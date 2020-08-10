using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class FixPsnTrophyCollectionFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophyCollections_PsnGames_GameId",
                table: "PsnTrophyCollections");

            migrationBuilder.DropIndex(
                name: "IX_PsnTrophyCollections_GameId",
                table: "PsnTrophyCollections");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "PsnTrophyCollections");

            migrationBuilder.CreateIndex(
                name: "IX_PsnTrophyCollections_PsnGameId",
                table: "PsnTrophyCollections",
                column: "PsnGameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophyCollections_PsnGames_PsnGameId",
                table: "PsnTrophyCollections",
                column: "PsnGameId",
                principalTable: "PsnGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophyCollections_PsnGames_PsnGameId",
                table: "PsnTrophyCollections");

            migrationBuilder.DropIndex(
                name: "IX_PsnTrophyCollections_PsnGameId",
                table: "PsnTrophyCollections");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "PsnTrophyCollections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PsnTrophyCollections_GameId",
                table: "PsnTrophyCollections",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophyCollections_PsnGames_GameId",
                table: "PsnTrophyCollections",
                column: "GameId",
                principalTable: "PsnGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
