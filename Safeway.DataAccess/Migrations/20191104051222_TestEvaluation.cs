using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class TestEvaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NormalEntEvaluationTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    EvluationEnt = table.Column<string>(maxLength: 300, nullable: true),
                    EvaluationStartDate = table.Column<DateTime>(nullable: false),
                    EvaluationEndDate = table.Column<DateTime>(nullable: false),
                    EvaluationLeader = table.Column<string>(maxLength: 200, nullable: true),
                    EvaluationTeamMember = table.Column<string>(maxLength: 500, nullable: true),
                    ModuleOne = table.Column<string>(maxLength: 200, nullable: true),
                    ModuleTwo = table.Column<string>(maxLength: 200, nullable: true),
                    ModuleThree = table.Column<string>(maxLength: 200, nullable: true),
                    EnterpriseId = table.Column<Guid>(nullable: false),
                    EnterpriseBasicInfoID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalEntEvaluationTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NormalEntEvaluationTemplates_EnterpriseBasicInfos_EnterpriseBasicInfoID",
                        column: x => x.EnterpriseBasicInfoID,
                        principalTable: "EnterpriseBasicInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NormalEntEvaluations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    LevelOneElement = table.Column<string>(maxLength: 300, nullable: true),
                    LevelTwoElement = table.Column<string>(maxLength: 300, nullable: true),
                    LevelThreeElement = table.Column<string>(maxLength: 300, nullable: true),
                    LevelFourID = table.Column<Guid>(nullable: false),
                    ComplianceStandard = table.Column<string>(maxLength: 500, nullable: true),
                    BasicRuleRequirement = table.Column<string>(maxLength: 500, nullable: true),
                    StandardScore = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    EvaluationDescription = table.Column<string>(nullable: true),
                    AssignTo = table.Column<string>(maxLength: 200, nullable: true),
                    ActualScore = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    NormalEntEvaId = table.Column<Guid>(nullable: false),
                    NormalEntEvaTempId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalEntEvaluations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Template_Evaluation",
                        column: x => x.NormalEntEvaTempId,
                        principalTable: "NormalEntEvaluationTemplates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailNotmalEntEvaluations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    EvaluateType = table.Column<int>(nullable: true),
                    EvaluationSelection = table.Column<int>(nullable: true),
                    DeductionReference = table.Column<int>(nullable: false),
                    Deduction = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    DeductionDescription = table.Column<string>(maxLength: 500, nullable: true),
                    NormalEntEvaluationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailNotmalEntEvaluations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Eva_Detail",
                        column: x => x.NormalEntEvaluationId,
                        principalTable: "NormalEntEvaluations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailNotmalEntEvaluations_NormalEntEvaluationId",
                table: "DetailNotmalEntEvaluations",
                column: "NormalEntEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluations_NormalEntEvaTempId",
                table: "NormalEntEvaluations",
                column: "NormalEntEvaTempId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluationTemplates_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationTemplates",
                column: "EnterpriseBasicInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailNotmalEntEvaluations");

            migrationBuilder.DropTable(
                name: "NormalEntEvaluations");

            migrationBuilder.DropTable(
                name: "NormalEntEvaluationTemplates");
        }
    }
}
