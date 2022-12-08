using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagerApi.Migrations
{
    public partial class UpdateModelOrderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Options");
        }
    }
}
