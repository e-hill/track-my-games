using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class RemovePsnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsnUserProgress_PsnUser_UserId",
                table: "PsnUserProgress");

            migrationBuilder.DropTable(
                name: "PsnUser");

            migrationBuilder.DropIndex(
                name: "IX_PsnUserProgress_UserId",
                table: "PsnUserProgress");

            migrationBuilder.CreateIndex(
                name: "IX_PsnUserProgress_TrophyId",
                table: "PsnUserProgress",
                columns: new[] { "TrophyId" },
                unique: true);

            migrationBuilder.DropIndex(
                name: "IX_PsnUserProgress_TrophyId_UserId",
                table: "PsnUserProgress");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PsnUserProgress");

            migrationBuilder.AddColumn<string>(
                name: "OnlineId",
                table: "PsnUserProgress",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PsnUserProgress_TrophyId_OnlineId",
                table: "PsnUserProgress",
                columns: new[] { "TrophyId", "OnlineId" },
                unique: true);

            migrationBuilder.DropIndex(
                name: "IX_PsnUserProgress_TrophyId",
                table: "PsnUserProgress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PsnUserProgress_TrophyId_OnlineId",
                table: "PsnUserProgress");

            migrationBuilder.DropColumn(
                name: "OnlineId",
                table: "PsnUserProgress");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PsnUserProgress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PsnUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OnlineId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsnUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PsnUserProgress_UserId",
                table: "PsnUserProgress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PsnUserProgress_TrophyId_UserId",
                table: "PsnUserProgress",
                columns: new[] { "TrophyId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PsnUser_OnlineId",
                table: "PsnUser",
                column: "OnlineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PsnUserProgress_PsnUser_UserId",
                table: "PsnUserProgress",
                column: "UserId",
                principalTable: "PsnUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
