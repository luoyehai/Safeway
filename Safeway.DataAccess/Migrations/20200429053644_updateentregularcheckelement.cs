using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class updateentregularcheckelement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "EntRegularCheckElement");

            migrationBuilder.DropColumn(
                name: "ParentElementId",
                table: "EntRegularCheckElement");

            migrationBuilder.AlterColumn<string>(
                name: "CheckPoint",
                table: "EntRegularCheckElement",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CheckContent",
                table: "EntRegularCheckElement",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CheckPoint",
                table: "EntRegularCheckElement",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "CheckContent",
                table: "EntRegularCheckElement",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "EntRegularCheckElement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ParentElementId",
                table: "EntRegularCheckElement",
                nullable: true);
        }
    }
}
