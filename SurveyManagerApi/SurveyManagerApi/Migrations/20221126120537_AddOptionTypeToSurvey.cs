using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagerApi.Migrations
{
    public partial class AddOptionTypeToSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OptionType",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptionType",
                table: "Surveys");
        }
    }
}
