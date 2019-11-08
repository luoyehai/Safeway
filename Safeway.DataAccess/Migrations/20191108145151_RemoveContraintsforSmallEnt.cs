using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class RemoveContraintsforSmallEnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_smallEntEvaluationBases_EnterpriseBasicInfos_EnterpriseBasicInfoID",
                table: "smallEntEvaluationBases");

            migrationBuilder.DropIndex(
                name: "IX_smallEntEvaluationBases_EnterpriseBasicInfoID",
                table: "smallEntEvaluationBases");

            migrationBuilder.DropColumn(
                name: "EnterpriseBasicInfoID",
                table: "smallEntEvaluationBases");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnterpriseBasicInfoID",
                table: "smallEntEvaluationBases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_smallEntEvaluationBases_EnterpriseBasicInfoID",
                table: "smallEntEvaluationBases",
                column: "EnterpriseBasicInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_smallEntEvaluationBases_EnterpriseBasicInfos_EnterpriseBasicInfoID",
                table: "smallEntEvaluationBases",
                column: "EnterpriseBasicInfoID",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
