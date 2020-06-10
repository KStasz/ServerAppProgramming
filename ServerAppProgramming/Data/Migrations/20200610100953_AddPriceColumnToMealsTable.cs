using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerAppProgramming.Data.Migrations
{
    public partial class AddPriceColumnToMealsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Meals",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Meals");
        }
    }
}
