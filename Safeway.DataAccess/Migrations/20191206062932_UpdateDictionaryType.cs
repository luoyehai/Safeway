using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class UpdateDictionaryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentCode",
                table: "SysDictionaryTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCode",
                table: "SysDictionaryTypes");
        }
    }
}
