using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class SimplifyDevPubTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameDevelopers_Developers_DeveloperId",
                table: "GameDevelopers");

            migrationBuilder.DropForeignKey(
                name: "FK_GamePublishers_Publishers_PublisherId",
                table: "GamePublishers");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropIndex(
                name: "IX_GamePublishers_PublisherId",
                table: "GamePublishers");

            migrationBuilder.DropIndex(
                name: "IX_GameDevelopers_DeveloperId",
                table: "GameDevelopers");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "GamePublishers");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "GameDevelopers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GamePublishers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GameDevelopers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "GamePublishers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GameDevelopers");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "GamePublishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "GameDevelopers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePublishers_PublisherId",
                table: "GamePublishers",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDevelopers_DeveloperId",
                table: "GameDevelopers",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameDevelopers_Developers_DeveloperId",
                table: "GameDevelopers",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GamePublishers_Publishers_PublisherId",
                table: "GamePublishers",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
