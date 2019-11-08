using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class UpdateEvaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basic_Contacts",
                table: "EnterpriseContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Basic_Finance",
                table: "EnterpriseFinanceInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Basic_YearYields",
                table: "EnterpriserYearYields");

            migrationBuilder.DropTable(
                name: "DetailNotmalEntEvaluations");

            migrationBuilder.DropTable(
                name: "NormalEntEvaluations");

            migrationBuilder.DropTable(
                name: "NormalEntEvaluationTemplates");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriserYearYields_EnterpriseBasicInfoId",
                table: "EnterpriserYearYields");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriseFinanceInfos_EnterpriseBasicId",
                table: "EnterpriseFinanceInfos");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriseContacts_EnterpriseBasicInfoId",
                table: "EnterpriseContacts");

            migrationBuilder.CreateTable(
                name: "NormalEntEvaluationBases",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    EnterpriseId = table.Column<Guid>(nullable: false),
                    EnterpriseBasicInfoID = table.Column<Guid>(nullable: true),
                    EvluationEnt = table.Column<string>(maxLength: 300, nullable: true),
                    EvaluationStartDate = table.Column<DateTime>(nullable: false),
                    EvaluationEndDate = table.Column<DateTime>(nullable: false),
                    EvaluationLeader = table.Column<string>(maxLength: 200, nullable: true),
                    ReportLeader = table.Column<string>(maxLength: 200, nullable: true),
                    EvaluationTeamMember = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ModuleOne = table.Column<string>(maxLength: 200, nullable: true),
                    ModuleTwo = table.Column<string>(maxLength: 200, nullable: true),
                    ModuleThree = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalEntEvaluationBases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NormalEntEvaluationBases_EnterpriseBasicInfos_EnterpriseBasicInfoID",
                        column: x => x.EnterpriseBasicInfoID,
                        principalTable: "EnterpriseBasicInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NormalEntEvaluationItems",
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
                    UnMatched = table.Column<bool>(nullable: false),
                    UnInvolved = table.Column<bool>(nullable: false),
                    ActualScore = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    EvaluationType = table.Column<int>(nullable: true),
                    NormalEntEvaluationBaseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalEntEvaluationItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NormalEntEvaluationUnmatchedItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    SmallEntEvaluationItemId = table.Column<string>(nullable: true),
                    UnMatchedItemReferDescription = table.Column<string>(maxLength: 500, nullable: true),
                    UnMatchedItemDescription = table.Column<string>(maxLength: 500, nullable: true),
                    DeductionReference = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    Deduction = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    NormalEntEvaluationBaseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalEntEvaluationUnmatchedItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "smallEntEvaluationBases",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    EnterpriseId = table.Column<Guid>(nullable: false),
                    EnterpriseBasicInfoID = table.Column<Guid>(nullable: true),
                    EvluationEnt = table.Column<string>(maxLength: 300, nullable: true),
                    EvaluationStartDate = table.Column<DateTime>(nullable: false),
                    EvaluationEndDate = table.Column<DateTime>(nullable: false),
                    EvaluationLeader = table.Column<string>(maxLength: 200, nullable: true),
                    ReportLeader = table.Column<string>(maxLength: 200, nullable: true),
                    EvaluationTeamMember = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ModuleOne = table.Column<string>(maxLength: 200, nullable: true),
                    ModuleTwo = table.Column<string>(maxLength: 200, nullable: true),
                    ModuleThree = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_smallEntEvaluationBases", x => x.ID);
                    table.ForeignKey(
                        name: "FK_smallEntEvaluationBases_EnterpriseBasicInfos_EnterpriseBasicInfoID",
                        column: x => x.EnterpriseBasicInfoID,
                        principalTable: "EnterpriseBasicInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SmallEntEvaluationItems",
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
                    UnMatched = table.Column<bool>(nullable: false),
                    UnInvolved = table.Column<bool>(nullable: false),
                    ActualScore = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    EvaluationType = table.Column<int>(nullable: true),
                    SmallEntEvaluationBaseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallEntEvaluationItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SmallEntEvaluationUnMatchedItems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    SmallEntEvaluationItemId = table.Column<string>(nullable: true),
                    UnMatchedItemReferDescription = table.Column<string>(maxLength: 500, nullable: true),
                    UnMatchedItemDescription = table.Column<string>(maxLength: 500, nullable: true),
                    DeductionReference = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    Deduction = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    SmallEntEvaluationBaseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallEntEvaluationUnMatchedItems", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluationBases_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationBases",
                column: "EnterpriseBasicInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_smallEntEvaluationBases_EnterpriseBasicInfoID",
                table: "smallEntEvaluationBases",
                column: "EnterpriseBasicInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormalEntEvaluationBases");

            migrationBuilder.DropTable(
                name: "NormalEntEvaluationItems");

            migrationBuilder.DropTable(
                name: "NormalEntEvaluationUnmatchedItems");

            migrationBuilder.DropTable(
                name: "smallEntEvaluationBases");

            migrationBuilder.DropTable(
                name: "SmallEntEvaluationItems");

            migrationBuilder.DropTable(
                name: "SmallEntEvaluationUnMatchedItems");

            migrationBuilder.CreateTable(
                name: "NormalEntEvaluationTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EnterpriseId = table.Column<Guid>(nullable: false),
                    EvaluationEndDate = table.Column<DateTime>(nullable: false),
                    EvaluationLeader = table.Column<string>(maxLength: 200, nullable: true),
                    EvaluationStartDate = table.Column<DateTime>(nullable: false),
                    EvaluationTeamMember = table.Column<string>(maxLength: 500, nullable: true),
                    EvluationEnt = table.Column<string>(maxLength: 300, nullable: true),
                    ModuleOne = table.Column<string>(maxLength: 200, nullable: true),
                    ModuleThree = table.Column<string>(maxLength: 200, nullable: true),
                    ModuleTwo = table.Column<string>(maxLength: 200, nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalEntEvaluationTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Basic_NormalEvaTemp",
                        column: x => x.EnterpriseId,
                        principalTable: "EnterpriseBasicInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NormalEntEvaluations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ActualScore = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    AssignTo = table.Column<string>(maxLength: 200, nullable: true),
                    BasicRuleRequirement = table.Column<string>(maxLength: 500, nullable: true),
                    ComplianceStandard = table.Column<string>(maxLength: 500, nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    EvaluationDescription = table.Column<string>(nullable: true),
                    LevelFourID = table.Column<Guid>(nullable: false),
                    LevelOneElement = table.Column<string>(maxLength: 300, nullable: true),
                    LevelThreeElement = table.Column<string>(maxLength: 300, nullable: true),
                    LevelTwoElement = table.Column<string>(maxLength: 300, nullable: true),
                    NormalEntEvaId = table.Column<Guid>(nullable: false),
                    NormalEntEvaTempId = table.Column<Guid>(nullable: false),
                    StandardScore = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
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
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Deduction = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    DeductionDescription = table.Column<string>(maxLength: 500, nullable: true),
                    DeductionReference = table.Column<int>(nullable: false),
                    EvaluateType = table.Column<int>(nullable: true),
                    EvaluationSelection = table.Column<int>(nullable: true),
                    NormalEntEvaluationId = table.Column<Guid>(nullable: false),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
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
                name: "IX_EnterpriserYearYields_EnterpriseBasicInfoId",
                table: "EnterpriserYearYields",
                column: "EnterpriseBasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseFinanceInfos_EnterpriseBasicId",
                table: "EnterpriseFinanceInfos",
                column: "EnterpriseBasicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseContacts_EnterpriseBasicInfoId",
                table: "EnterpriseContacts",
                column: "EnterpriseBasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailNotmalEntEvaluations_NormalEntEvaluationId",
                table: "DetailNotmalEntEvaluations",
                column: "NormalEntEvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluations_NormalEntEvaTempId",
                table: "NormalEntEvaluations",
                column: "NormalEntEvaTempId");

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluationTemplates_EnterpriseId",
                table: "NormalEntEvaluationTemplates",
                column: "EnterpriseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Basic_Contacts",
                table: "EnterpriseContacts",
                column: "EnterpriseBasicInfoId",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Basic_Finance",
                table: "EnterpriseFinanceInfos",
                column: "EnterpriseBasicId",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Basic_YearYields",
                table: "EnterpriserYearYields",
                column: "EnterpriseBasicInfoId",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
