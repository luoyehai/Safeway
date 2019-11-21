using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class addExportTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmEntEvaluationTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LevelFourID = table.Column<Guid>(nullable: false),
                    ComplianceStandard = table.Column<string>(nullable: true),
                    ActualScore = table.Column<decimal>(nullable: false),
                    ScoringMethod = table.Column<string>(nullable: true),
                    Deduction = table.Column<decimal>(nullable: false),
                    UnMatchedItemDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmEntEvaluationTemplates", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmEntEvaluationTemplates");
        }
    }
}
