using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class update_reportfileId_smallentevaluationbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ReportFileId",
                table: "smallEntEvaluationBases",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReportFileId",
                table: "smallEntEvaluationBases",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
