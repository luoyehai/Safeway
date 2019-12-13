using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class UpdateExportAddReportDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EvaluationEndDate",
                table: "SmEntEvaluationGenerals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EvaluationLeader",
                table: "SmEntEvaluationGenerals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvaluationTeamMember",
                table: "SmEntEvaluationGenerals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluationEndDate",
                table: "SmEntEvaluationGenerals");

            migrationBuilder.DropColumn(
                name: "EvaluationLeader",
                table: "SmEntEvaluationGenerals");

            migrationBuilder.DropColumn(
                name: "EvaluationTeamMember",
                table: "SmEntEvaluationGenerals");
        }
    }
}
