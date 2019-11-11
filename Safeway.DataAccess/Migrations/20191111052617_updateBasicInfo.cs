using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class updateBasicInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EnterpriseBusinessinfos_EnterpriseBasicInfoId",
                table: "EnterpriseBusinessinfos");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseBusinessinfos_EnterpriseBasicInfoId",
                table: "EnterpriseBusinessinfos",
                column: "EnterpriseBasicInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EnterpriseBusinessinfos_EnterpriseBasicInfoId",
                table: "EnterpriseBusinessinfos");

            migrationBuilder.CreateIndex(
                name: "IX_EnterpriseBusinessinfos_EnterpriseBasicInfoId",
                table: "EnterpriseBusinessinfos",
                column: "EnterpriseBasicInfoId");
        }
    }
}
