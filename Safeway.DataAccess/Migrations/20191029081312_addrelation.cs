using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class addrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnterpriseBasicInfoId",
                table: "EnterpriseContacts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EnterpriserYearYields",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    FiscalYear = table.Column<string>(nullable: true),
                    YearYieldValue = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    EnterpriseBasicInfoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriserYearYields", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Basic_YearYields",
                        column: x => x.EnterpriseBasicInfoId,
                        principalTable: "EnterpriseBasicInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseContacts_EnterpriseBasicInfoId",
                table: "EnterpriseContacts",
                column: "EnterpriseBasicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriserYearYields_EnterpriseBasicInfoId",
                table: "EnterpriserYearYields",
                column: "EnterpriseBasicInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basic_Contacts",
                table: "EnterpriseContacts",
                column: "EnterpriseBasicInfoId",
                principalTable: "EnterpriseBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basic_Contacts",
                table: "EnterpriseContacts");

            migrationBuilder.DropTable(
                name: "EnterpriserYearYields");

            migrationBuilder.DropIndex(
                name: "IX_EnterpriseContacts_EnterpriseBasicInfoId",
                table: "EnterpriseContacts");

            migrationBuilder.DropColumn(
                name: "EnterpriseBasicInfoId",
                table: "EnterpriseContacts");
        }
    }
}
