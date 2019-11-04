using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class updateRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NormalEntEvaluationTemplates_EnterpriseBasicInfos_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationTemplates");

            migrationBuilder.DropIndex(
                name: "IX_NormalEntEvaluationTemplates_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationTemplates");

            migrationBuilder.DropColumn(
                name: "EnterpriseBasicInfoID",
                table: "NormalEntEvaluationTemplates");

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluationTemplates_EnterpriseId",
                table: "NormalEntEvaluationTemplates",
                column: "EnterpriseId",
                unique: true);

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
                name: "FK_Basic_NormalEvaTemp",
                table: "NormalEntEvaluationTemplates");

            migrationBuilder.DropIndex(
                name: "IX_NormalEntEvaluationTemplates_EnterpriseId",
                table: "NormalEntEvaluationTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "EnterpriseBasicInfoID",
                table: "NormalEntEvaluationTemplates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluationTemplates_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationTemplates",
                column: "EnterpriseBasicInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_NormalEntEvaluationTemplates_EnterpriseBasicInfos_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationTemplates",
                column: "EnterpriseBasicInfoID",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
