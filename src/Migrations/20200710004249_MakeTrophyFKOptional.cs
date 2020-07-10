using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class MakeTrophyFKOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophies_PsnTrophyCollections_CollectionId",
                table: "PsnTrophies");

            migrationBuilder.AlterColumn<int>(
                name: "CollectionId",
                table: "PsnTrophies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophies_PsnTrophyCollections_CollectionId",
                table: "PsnTrophies",
                column: "CollectionId",
                principalTable: "PsnTrophyCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophies_PsnTrophyCollections_CollectionId",
                table: "PsnTrophies");

            migrationBuilder.AlterColumn<int>(
                name: "CollectionId",
                table: "PsnTrophies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophies_PsnTrophyCollections_CollectionId",
                table: "PsnTrophies",
                column: "CollectionId",
                principalTable: "PsnTrophyCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
