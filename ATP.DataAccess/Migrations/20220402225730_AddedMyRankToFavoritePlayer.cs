using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATP.DataAccess.Migrations
{
    public partial class AddedMyRankToFavoritePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTie",
                table: "FavoritePlayers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "FavoritePlayers");

            migrationBuilder.RenameColumn(
                name: "Rank",
                table: "FavoritePlayers",
                newName: "MyRank");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyRank",
                table: "FavoritePlayers",
                newName: "Rank");

            migrationBuilder.AddColumn<bool>(
                name: "IsTie",
                table: "FavoritePlayers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "FavoritePlayers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
