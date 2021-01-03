using Microsoft.EntityFrameworkCore.Migrations;

namespace mouzikty.Migrations
{
    public partial class correction3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlbumID",
                table: "Albums",
                newName: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Albums",
                newName: "AlbumID");
        }
    }
}
