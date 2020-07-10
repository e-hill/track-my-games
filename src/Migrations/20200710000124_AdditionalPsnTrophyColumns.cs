using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackMyGames.Migrations
{
    public partial class AdditionalPsnTrophyColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "PsnTrophies",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "EarnedRate",
                table: "PsnTrophies",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "PsnTrophies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "PsnTrophies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PsnTrophies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PsnId",
                table: "PsnTrophies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rare",
                table: "PsnTrophies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SmallIconUrl",
                table: "PsnTrophies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PsnTrophies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "EarnedRate",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "PsnId",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "Rare",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "SmallIconUrl",
                table: "PsnTrophies");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PsnTrophies");
        }
    }
}
