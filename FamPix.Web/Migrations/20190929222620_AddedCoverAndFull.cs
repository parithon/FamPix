using Microsoft.EntityFrameworkCore.Migrations;

namespace FamPix.Web.Migrations
{
    public partial class AddedCoverAndFull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Full",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Full",
                table: "Images");
        }
    }
}
