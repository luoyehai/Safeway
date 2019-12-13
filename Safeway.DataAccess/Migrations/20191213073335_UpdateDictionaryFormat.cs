using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class UpdateDictionaryFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCode",
                table: "SysDictionaryTypes");

            migrationBuilder.AddColumn<string>(
                name: "ChildrenCode",
                table: "SysDictionaryItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildrenCode",
                table: "SysDictionaryItems");

            migrationBuilder.AddColumn<string>(
                name: "ParentCode",
                table: "SysDictionaryTypes",
                nullable: true);
        }
    }
}
