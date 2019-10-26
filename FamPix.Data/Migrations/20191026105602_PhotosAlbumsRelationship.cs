using Microsoft.EntityFrameworkCore.Migrations;

namespace FamPix.Data.Migrations
{
    public partial class PhotosAlbumsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotosAlbums",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosAlbums", x => new { x.PhotoId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_PhotosAlbums_Photos_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotosAlbums_Albums_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotosAlbums_AlbumId",
                table: "PhotosAlbums",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotosAlbums");
        }
    }
}
