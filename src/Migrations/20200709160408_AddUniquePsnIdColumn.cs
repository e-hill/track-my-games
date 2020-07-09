using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class AddUniquePsnIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PsnId",
                table: "PsnTrophyCollections",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PsnTrophyCollections_PsnId",
                table: "PsnTrophyCollections",
                column: "PsnId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PsnTrophyCollections_PsnId",
                table: "PsnTrophyCollections");

            migrationBuilder.AlterColumn<string>(
                name: "PsnId",
                table: "PsnTrophyCollections",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
