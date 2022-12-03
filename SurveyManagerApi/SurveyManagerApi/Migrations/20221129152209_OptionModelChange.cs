using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagerApi.Migrations
{
    public partial class OptionModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Answered",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPicked",
                table: "Options",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answered",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "IsPicked",
                table: "Options");
        }
    }
}
