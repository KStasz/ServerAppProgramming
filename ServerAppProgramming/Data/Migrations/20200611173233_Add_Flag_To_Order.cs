using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerAppProgramming.Data.Migrations
{
    public partial class Add_Flag_To_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInWeryfication",
                table: "Order",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInWeryfication",
                table: "Order");
        }
    }
}
