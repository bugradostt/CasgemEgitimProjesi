using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasgemEgitim.DataAccessLayer.Migrations
{
    public partial class mig_video_edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoName",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoName",
                table: "Videos");
        }
    }
}
