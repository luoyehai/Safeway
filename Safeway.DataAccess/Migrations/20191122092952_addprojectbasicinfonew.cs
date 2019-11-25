using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class addprojectbasicinfonew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectBasicInfos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    ProjectName = table.Column<string>(maxLength: 100, nullable: false),
                    ProjectDescription = table.Column<string>(maxLength: 500, nullable: true),
                    ProjectType = table.Column<int>(nullable: true),
                    ProjectOnwer = table.Column<string>(nullable: true),
                    ProjectMember = table.Column<int>(nullable: false),
                    ProjectStartDate = table.Column<DateTime>(nullable: true),
                    ProjectEndDate = table.Column<DateTime>(nullable: true),
                    ProjectStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBasicInfos", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectBasicInfos");
        }
    }
}
