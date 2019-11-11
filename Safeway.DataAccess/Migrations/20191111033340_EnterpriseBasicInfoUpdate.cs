using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class EnterpriseBasicInfoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReportLeader",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleTwo",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleThree",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleOne",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EvluationEnt",
                table: "smallEntEvaluationBases",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EvaluationTeamMember",
                table: "smallEntEvaluationBases",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EvaluationLeader",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FinanceInfoID",
                table: "EnterpriseBasicInfos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnterpriseBusinessinfos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    SafetyServiceType = table.Column<int>(nullable: true),
                    OtherSafetyServiceType = table.Column<string>(nullable: true),
                    CertificateLevel = table.Column<string>(maxLength: 50, nullable: true),
                    ExpireDate = table.Column<string>(maxLength: 50, nullable: true),
                    OriginalServiceCom = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    EnterpriseBasicInfoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseBusinessinfos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnterpriseBusinessinfos_EnterpriseBasicInfos_EnterpriseBasicInfoId",
                        column: x => x.EnterpriseBasicInfoId,
                        principalTable: "EnterpriseBasicInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriserYearYields_EnterpriseBasicInfoId",
                table: "EnterpriserYearYields",
                column: "EnterpriseBasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseContacts_EnterpriseBasicInfoId",
                table: "EnterpriseContacts",
                column: "EnterpriseBasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseBasicInfos_FinanceInfoID",
                table: "EnterpriseBasicInfos",
                column: "FinanceInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseBusinessinfos_EnterpriseBasicInfoId",
                table: "EnterpriseBusinessinfos",
                column: "EnterpriseBasicInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpriseBasicInfos_EnterpriseFinanceInfos_FinanceInfoID",
                table: "EnterpriseBasicInfos",
                column: "FinanceInfoID",
                principalTable: "EnterpriseFinanceInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpriseContacts_EnterpriseBasicInfos_EnterpriseBasicInfoId",
                table: "EnterpriseContacts",
                column: "EnterpriseBasicInfoId",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpriserYearYields_EnterpriseBasicInfos_EnterpriseBasicInfoId",
                table: "EnterpriserYearYields",
                column: "EnterpriseBasicInfoId",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnterpriseBasicInfos_EnterpriseFinanceInfos_FinanceInfoID",
                table: "EnterpriseBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_EnterpriseContacts_EnterpriseBasicInfos_EnterpriseBasicInfoId",
                table: "EnterpriseContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_EnterpriserYearYields_EnterpriseBasicInfos_EnterpriseBasicInfoId",
                table: "EnterpriserYearYields");

            migrationBuilder.DropTable(
                name: "EnterpriseBusinessinfos");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriserYearYields_EnterpriseBasicInfoId",
                table: "EnterpriserYearYields");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriseContacts_EnterpriseBasicInfoId",
                table: "EnterpriseContacts");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriseBasicInfos_FinanceInfoID",
                table: "EnterpriseBasicInfos");

            migrationBuilder.DropColumn(
                name: "FinanceInfoID",
                table: "EnterpriseBasicInfos");

            migrationBuilder.AlterColumn<string>(
                name: "ReportLeader",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleTwo",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleThree",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ModuleOne",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "EvluationEnt",
                table: "smallEntEvaluationBases",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "EvaluationTeamMember",
                table: "smallEntEvaluationBases",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "EvaluationLeader",
                table: "smallEntEvaluationBases",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
