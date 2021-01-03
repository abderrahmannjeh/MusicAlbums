﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace mouzikty.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Albums_AlbumId",
                table: "Musics");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Musics",
                newName: "AlbumID");

            migrationBuilder.RenameIndex(
                name: "IX_Musics_AlbumId",
                table: "Musics",
                newName: "IX_Musics_AlbumID");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumID",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Albums_AlbumID",
                table: "Musics",
                column: "AlbumID",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Albums_AlbumID",
                table: "Musics");

            migrationBuilder.RenameColumn(
                name: "AlbumID",
                table: "Musics",
                newName: "AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Musics_AlbumID",
                table: "Musics",
                newName: "IX_Musics_AlbumId");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Musics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Albums_AlbumId",
                table: "Musics",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
