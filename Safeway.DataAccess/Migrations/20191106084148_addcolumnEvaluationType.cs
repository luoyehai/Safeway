using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class addcolumnEvaluationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NormalEntEvaTempId",
                table: "NormalEntEvaluations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "EvaluationType",
                table: "EnterpriseReviewElements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluationTemplates_EnterpriseId",
                table: "NormalEntEvaluationTemplates",
                column: "EnterpriseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluations_NormalEntEvaTempId",
                table: "NormalEntEvaluations",
                column: "NormalEntEvaTempId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailNotmalEntEvaluations_NormalEntEvaluationId",
                table: "DetailNotmalEntEvaluations",
                column: "NormalEntEvaluationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eva_Detail",
                table: "DetailNotmalEntEvaluations",
                column: "NormalEntEvaluationId",
                principalTable: "NormalEntEvaluations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Template_Evaluation",
                table: "NormalEntEvaluations",
                column: "NormalEntEvaTempId",
                principalTable: "NormalEntEvaluationTemplates",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Basic_NormalEvaTemp",
                table: "NormalEntEvaluationTemplates",
                column: "EnterpriseId",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eva_Detail",
                table: "DetailNotmalEntEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Template_Evaluation",
                table: "NormalEntEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Basic_NormalEvaTemp",
                table: "NormalEntEvaluationTemplates");

            migrationBuilder.DropIndex(
                name: "IX_NormalEntEvaluationTemplates_EnterpriseId",
                table: "NormalEntEvaluationTemplates");

            migrationBuilder.DropIndex(
                name: "IX_NormalEntEvaluations_NormalEntEvaTempId",
                table: "NormalEntEvaluations");

            migrationBuilder.DropIndex(
                name: "IX_DetailNotmalEntEvaluations_NormalEntEvaluationId",
                table: "DetailNotmalEntEvaluations");

            migrationBuilder.DropColumn(
                name: "NormalEntEvaTempId",
                table: "NormalEntEvaluations");

            migrationBuilder.DropColumn(
                name: "EvaluationType",
                table: "EnterpriseReviewElements");
        }
    }
}
