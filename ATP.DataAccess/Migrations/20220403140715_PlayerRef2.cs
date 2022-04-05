using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATP.DataAccess.Migrations
{
    public partial class PlayerRef2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PlayerRef",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRef", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerRef");

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
    }
}
