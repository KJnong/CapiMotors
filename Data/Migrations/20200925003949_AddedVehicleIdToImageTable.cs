using Microsoft.EntityFrameworkCore.Migrations;

namespace CapiMotors.Data.Migrations
{
    public partial class AddedVehicleIdToImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Vehicles_VehicleId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_VehicleId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Images_VehicleId",
                table: "Images",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Vehicles_VehicleId",
                table: "Images",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Vehicles_VehicleId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_VehicleId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "VehicleId1",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_VehicleId1",
                table: "Images",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Vehicles_VehicleId1",
                table: "Images",
                column: "VehicleId1",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
