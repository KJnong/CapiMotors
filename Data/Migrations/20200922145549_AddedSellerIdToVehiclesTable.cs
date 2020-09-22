using Microsoft.EntityFrameworkCore.Migrations;

namespace CapiMotors.Data.Migrations
{
    public partial class AddedSellerIdToVehiclesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_MyPropertyId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_MyPropertyId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "MyPropertyId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SellerId",
                table: "Vehicles",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_SellerId",
                table: "Vehicles",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_SellerId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_SellerId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "MyPropertyId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MyPropertyId",
                table: "Vehicles",
                column: "MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_MyPropertyId",
                table: "Vehicles",
                column: "MyPropertyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
