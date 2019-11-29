using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class UpdateBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SafetyServiceType",
                table: "EnterpriseBusinessinfos",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SafetyServiceType",
                table: "EnterpriseBusinessinfos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
