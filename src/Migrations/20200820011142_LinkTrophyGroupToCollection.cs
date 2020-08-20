using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class LinkTrophyGroupToCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "PsnTrophyGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PsnTrophyGroups_CollectionId",
                table: "PsnTrophyGroups",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PsnTrophyGroups_PsnTrophyCollections_CollectionId",
                table: "PsnTrophyGroups",
                column: "CollectionId",
                principalTable: "PsnTrophyCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnTrophyGroups_PsnTrophyCollections_CollectionId",
                table: "PsnTrophyGroups");

            migrationBuilder.DropIndex(
                name: "IX_PsnTrophyGroups_CollectionId",
                table: "PsnTrophyGroups");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "PsnTrophyGroups");
        }
    }
}
