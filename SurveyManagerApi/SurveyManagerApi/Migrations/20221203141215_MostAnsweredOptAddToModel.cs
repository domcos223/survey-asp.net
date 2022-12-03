using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyManagerApi.Migrations
{
    public partial class MostAnsweredOptAddToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MostAnsweredOp",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MostAnsweredOp",
                table: "Questions");
        }
    }
}
