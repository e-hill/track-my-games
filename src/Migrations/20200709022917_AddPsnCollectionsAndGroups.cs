using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class AddPsnCollectionsAndGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophies_Games_GameId",
                table: "PsnTrophies");

            migrationBuilder.DropIndex(
                name: "IX_PsnTrophies_GameId",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SmallIconUrl",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "PsnTrophies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "PsnTrophies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PsnTrophyCollections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PsnId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    IconUrl = table.Column<string>(nullable: true),
                    SmallIconUrl = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsnTrophyCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PsnTrophyCollections_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PsnTrophyGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsnTrophyGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PsnTrophies_CollectionId",
                table: "PsnTrophies",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PsnTrophies_GroupId",
                table: "PsnTrophies",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PsnTrophyCollections_GameId",
                table: "PsnTrophyCollections",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophies_PsnTrophyCollections_CollectionId",
                table: "PsnTrophies",
                column: "CollectionId",
                principalTable: "PsnTrophyCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophies_PsnTrophyGroups_GroupId",
                table: "PsnTrophies",
                column: "GroupId",
                principalTable: "PsnTrophyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophies_PsnTrophyCollections_CollectionId",
                table: "PsnTrophies");

            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophies_PsnTrophyGroups_GroupId",
                table: "PsnTrophies");

            migrationBuilder.DropTable(
                name: "PsnTrophyCollections");

            migrationBuilder.DropTable(
                name: "PsnTrophyGroups");

            migrationBuilder.DropIndex(
                name: "IX_PsnTrophies_CollectionId",
                table: "PsnTrophies");

            migrationBuilder.DropIndex(
                name: "IX_PsnTrophies_GroupId",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "PsnTrophies");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "PsnTrophies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Games",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallIconUrl",
                table: "Games",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PsnTrophies_GameId",
                table: "PsnTrophies",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophies_Games_GameId",
                table: "PsnTrophies",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
