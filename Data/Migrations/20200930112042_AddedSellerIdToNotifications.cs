using Microsoft.EntityFrameworkCore.Migrations;

namespace CapiMotors.Data.Migrations
{
    public partial class AddedSellerIdToNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "Notifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Notifications");
        }
    }
}
