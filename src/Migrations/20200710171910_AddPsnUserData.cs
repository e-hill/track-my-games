using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class AddPsnUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PsnUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OnlineId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsnUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PsnUserProgress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Earned = table.Column<bool>(nullable: false),
                    EarnedDate = table.Column<DateTime>(nullable: false),
                    TrophyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsnUserProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PsnUserProgress_PsnTrophies_TrophyId",
                        column: x => x.TrophyId,
                        principalTable: "PsnTrophies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PsnUserProgress_PsnUser_UserId",
                        column: x => x.UserId,
                        principalTable: "PsnUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PsnUser_OnlineId",
                table: "PsnUser",
                column: "OnlineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PsnUserProgress_UserId",
                table: "PsnUserProgress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PsnUserProgress_TrophyId_UserId",
                table: "PsnUserProgress",
                columns: new[] { "TrophyId", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PsnUserProgress");

            migrationBuilder.DropTable(
                name: "PsnUser");
        }
    }
}
