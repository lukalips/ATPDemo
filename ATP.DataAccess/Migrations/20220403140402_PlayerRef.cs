using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATP.DataAccess.Migrations
{
    public partial class PlayerRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoritePlayers",
                table: "FavoritePlayers");

            migrationBuilder.RenameTable(
                name: "FavoritePlayers",
                newName: "FavoritePlayer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoritePlayer",
                table: "FavoritePlayer",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoritePlayer",
                table: "FavoritePlayer");

            migrationBuilder.RenameTable(
                name: "FavoritePlayer",
                newName: "FavoritePlayers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoritePlayers",
                table: "FavoritePlayers",
                column: "Id");
        }
    }
}
