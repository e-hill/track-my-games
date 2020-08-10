using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class AddPsnGamesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophyCollections_Games_GameId",
                table: "PsnTrophyCollections");

            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "PsnTrophyGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "PsnTrophyGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PsnId",
                table: "PsnTrophyGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallIconUrl",
                table: "PsnTrophyGroups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PsnGameId",
                table: "PsnTrophyCollections",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PsnGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    System = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsnGames", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophyCollections_PsnGames_GameId",
                table: "PsnTrophyCollections",
                column: "GameId",
                principalTable: "PsnGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophyCollections_PsnGames_GameId",
                table: "PsnTrophyCollections");

            migrationBuilder.DropTable(
                name: "PsnGames");

            migrationBuilder.DropColumn(
                name: "Detail",
                table: "PsnTrophyGroups");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "PsnTrophyGroups");

            migrationBuilder.DropColumn(
                name: "PsnId",
                table: "PsnTrophyGroups");

            migrationBuilder.DropColumn(
                name: "SmallIconUrl",
                table: "PsnTrophyGroups");

            migrationBuilder.DropColumn(
                name: "PsnGameId",
                table: "PsnTrophyCollections");

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophyCollections_Games_GameId",
                table: "PsnTrophyCollections",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
