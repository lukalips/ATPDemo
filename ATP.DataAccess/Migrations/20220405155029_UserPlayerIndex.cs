using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATP.DataAccess.Migrations
{
    public partial class UserPlayerIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "FavoritePlayers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlayers_UserId_PlayerId",
                table: "FavoritePlayers",
                columns: new[] { "UserId", "PlayerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FavoritePlayers_UserId_PlayerId",
                table: "FavoritePlayers");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "FavoritePlayers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
