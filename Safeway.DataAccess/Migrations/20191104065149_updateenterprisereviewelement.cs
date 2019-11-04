using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class updateenterprisereviewelement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "EnterpriseReviewElements");

            migrationBuilder.AlterColumn<string>(
                name: "ParentElementId",
                table: "EnterpriseReviewElements",
                nullable: true,
                oldClrType: typeof(Guid));

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ParentElementId",
                table: "EnterpriseReviewElements",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "EnterpriseReviewElements",
                nullable: false,
                defaultValue: 0);
        }
    }
}
