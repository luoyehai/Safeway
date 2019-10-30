using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class addreivewlevel2element : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReviewTempType",
                table: "ReviewBasicElements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ReviewLevel2Elements",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    ElementName = table.Column<string>(maxLength: 100, nullable: false),
                    ElementStandard = table.Column<string>(maxLength: 500, nullable: false),
                    Order = table.Column<string>(nullable: false),
                    TotalScore = table.Column<int>(nullable: false),
                    BasicElementId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewLevel2Elements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Basic_Element",
                        column: x => x.BasicElementId,
                        principalTable: "ReviewBasicElements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewLevel2Elements_BasicElementId",
                table: "ReviewLevel2Elements",
                column: "BasicElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewLevel2Elements");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewTempType",
                table: "ReviewBasicElements",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
