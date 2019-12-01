using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class UpdateExportTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LevelOneElement",
                table: "SmEntEvaluationTemplates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LevelTwoElement",
                table: "SmEntEvaluationTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelOneElement",
                table: "SmEntEvaluationTemplates");

            migrationBuilder.DropColumn(
                name: "LevelTwoElement",
                table: "SmEntEvaluationTemplates");
        }
    }
}
