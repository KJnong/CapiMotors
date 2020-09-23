using Microsoft.EntityFrameworkCore.Migrations;

namespace CapiMotors.Data.Migrations
{
    public partial class ChangedImageNamePathToImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
