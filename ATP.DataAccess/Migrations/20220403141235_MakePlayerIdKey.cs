using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATP.DataAccess.Migrations
{
    public partial class MakePlayerIdKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerRef",
                table: "PlayerRef");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlayerRef");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "PlayerRef",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerRef",
                table: "PlayerRef",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerRef",
                table: "PlayerRef");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerId",
                table: "PlayerRef",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlayerRef",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerRef",
                table: "PlayerRef",
                column: "Id");
        }
    }
}
