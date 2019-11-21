using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class update_smallentevaluationitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllMatched",
                table: "SmallEntEvaluationItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEvaluated",
                table: "SmallEntEvaluationItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "smallEntEvaluationBases",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllMatched",
                table: "SmallEntEvaluationItems");

            migrationBuilder.DropColumn(
                name: "IsEvaluated",
                table: "SmallEntEvaluationItems");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "smallEntEvaluationBases",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
