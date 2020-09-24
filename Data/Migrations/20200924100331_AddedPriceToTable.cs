using Microsoft.EntityFrameworkCore.Migrations;

namespace CapiMotors.Data.Migrations
{
    public partial class AddedPriceToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Vehicles");
        }
    }
}
