using Microsoft.EntityFrameworkCore.Migrations;

namespace FamPix.Web.Migrations
{
    public partial class AddedThumbnailColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "Images");
        }
    }
}
