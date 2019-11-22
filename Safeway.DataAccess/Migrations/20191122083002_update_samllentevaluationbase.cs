using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class update_samllentevaluationbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "smallEntEvaluationBases",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Score",
                table: "smallEntEvaluationBases",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "smallEntEvaluationBases");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "smallEntEvaluationBases");
        }
    }
}
