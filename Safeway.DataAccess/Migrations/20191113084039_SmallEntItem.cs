using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class SmallEntItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelFourOrder",
                table: "SmallEntEvaluationItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelOneOrder",
                table: "SmallEntEvaluationItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelThreeOrder",
                table: "SmallEntEvaluationItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelTwoOrder",
                table: "SmallEntEvaluationItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelFourOrder",
                table: "SmallEntEvaluationItems");

            migrationBuilder.DropColumn(
                name: "LevelOneOrder",
                table: "SmallEntEvaluationItems");

            migrationBuilder.DropColumn(
                name: "LevelThreeOrder",
                table: "SmallEntEvaluationItems");

            migrationBuilder.DropColumn(
                name: "LevelTwoOrder",
                table: "SmallEntEvaluationItems");
        }
    }
}
