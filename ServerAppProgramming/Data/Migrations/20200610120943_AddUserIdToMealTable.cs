using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerAppProgramming.Data.Migrations
{
    public partial class AddUserIdToMealTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Meals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Meals");
        }
    }
}
