using Microsoft.EntityFrameworkCore.Migrations;

namespace mouzikty.Migrations
{
    public partial class addrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_ArtisteId",
                table: "Musics");

            migrationBuilder.RenameColumn(
                name: "ArtisteId",
                table: "Musics",
                newName: "ArtisteID");

            migrationBuilder.RenameIndex(
                name: "IX_Musics_ArtisteId",
                table: "Musics",
                newName: "IX_Musics_ArtisteID");

            migrationBuilder.AlterColumn<int>(
                name: "ArtisteID",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_ArtisteID",
                table: "Musics",
                column: "ArtisteID",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_ArtisteID",
                table: "Musics");

            migrationBuilder.RenameColumn(
                name: "ArtisteID",
                table: "Musics",
                newName: "ArtisteId");

            migrationBuilder.RenameIndex(
                name: "IX_Musics_ArtisteID",
                table: "Musics",
                newName: "IX_Musics_ArtisteId");

            migrationBuilder.AlterColumn<int>(
                name: "ArtisteId",
                table: "Musics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_ArtisteId",
                table: "Musics",
                column: "ArtisteId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
