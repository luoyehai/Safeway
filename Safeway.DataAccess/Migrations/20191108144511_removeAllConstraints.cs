using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class removeAllConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NormalEntEvaluationBases_EnterpriseBasicInfos_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationBases");

            migrationBuilder.DropIndex(
                name: "IX_NormalEntEvaluationBases_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationBases");

            migrationBuilder.DropColumn(
                name: "EnterpriseBasicInfoID",
                table: "NormalEntEvaluationBases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnterpriseBasicInfoID",
                table: "NormalEntEvaluationBases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NormalEntEvaluationBases_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationBases",
                column: "EnterpriseBasicInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_NormalEntEvaluationBases_EnterpriseBasicInfos_EnterpriseBasicInfoID",
                table: "NormalEntEvaluationBases",
                column: "EnterpriseBasicInfoID",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
