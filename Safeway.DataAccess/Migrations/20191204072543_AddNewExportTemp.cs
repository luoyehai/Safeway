using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class AddNewExportTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvaluationTeamInfos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProjectID = table.Column<string>(nullable: true),
                    SmallEntEvaBaseID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationTeamInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SmEntEvaluationGenerals",
                columns: table => new
                {
                    EnterpriseID = table.Column<Guid>(nullable: false),
                    ComapanyName = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true),
                    EvaluationStartDate = table.Column<DateTime>(nullable: false),
                    LegalRepresentative = table.Column<string>(nullable: true),
                    LegalRepTel = table.Column<string>(nullable: true),
                    LegalRepMobile = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactTel = table.Column<string>(nullable: true),
                    ContactFax = table.Column<string>(nullable: true),
                    ContactMobile = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmEntEvaluationGenerals", x => x.EnterpriseID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EvaluationTeamInfos");

            migrationBuilder.DropTable(
                name: "SmEntEvaluationGenerals");
        }
    }
}
