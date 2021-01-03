using Microsoft.EntityFrameworkCore.Migrations;

namespace mouzikty.Migrations
{
    public partial class correction2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Albums",
                newName: "AlbumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlbumID",
                table: "Albums",
                newName: "Id");
        }
    }
}
