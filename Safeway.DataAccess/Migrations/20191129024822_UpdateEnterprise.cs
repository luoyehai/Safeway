using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class UpdateEnterprise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_EnterpriseBasicInfos_EnterpriseFinanceInfos_FinanceInfoID",
            //    table: "EnterpriseBasicInfos");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_EnterpriseBusinessinfos_EnterpriseBasicInfos_EnterpriseBasicInfoId",
            //    table: "EnterpriseBusinessinfos");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_EnterpriseContacts_EnterpriseBasicInfos_EnterpriseBasicInfoId",
            //    table: "EnterpriseContacts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_EnterpriserYearYields_EnterpriseBasicInfos_EnterpriseBasicInfoId",
            //    table: "EnterpriserYearYields");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriserYearYields_EnterpriseBasicInfoId",
                table: "EnterpriserYearYields");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriseContacts_EnterpriseBasicInfoId",
                table: "EnterpriseContacts");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriseBusinessinfos_EnterpriseBasicInfoId",
                table: "EnterpriseBusinessinfos");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriseBasicInfos_FinanceInfoID",
                table: "EnterpriseBasicInfos");

            migrationBuilder.DropColumn(
                name: "FinanceInfoID",
                table: "EnterpriseBasicInfos");

            migrationBuilder.AlterColumn<string>(
                name: "TermsofTrade",
                table: "EnterpriseBasicInfos",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyScale",
                table: "EnterpriseBasicInfos",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TermsofTrade",
                table: "EnterpriseBasicInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyScale",
                table: "EnterpriseBasicInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FinanceInfoID",
                table: "EnterpriseBasicInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriserYearYields_EnterpriseBasicInfoId",
                table: "EnterpriserYearYields",
                column: "EnterpriseBasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseContacts_EnterpriseBasicInfoId",
                table: "EnterpriseContacts",
                column: "EnterpriseBasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseBusinessinfos_EnterpriseBasicInfoId",
                table: "EnterpriseBusinessinfos",
                column: "EnterpriseBasicInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseBasicInfos_FinanceInfoID",
                table: "EnterpriseBasicInfos",
                column: "FinanceInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpriseBasicInfos_EnterpriseFinanceInfos_FinanceInfoID",
                table: "EnterpriseBasicInfos",
                column: "FinanceInfoID",
                principalTable: "EnterpriseFinanceInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnterpriseBusinessinfos_EnterpriseBasicInfos_EnterpriseBasicInfoId",
                table: "EnterpriseBusinessinfos",
                column: "EnterpriseBasicInfoId",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
    }
}
