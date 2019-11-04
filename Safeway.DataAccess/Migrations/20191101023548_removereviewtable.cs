﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class removereviewtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewLevel2Elements");

            migrationBuilder.DropTable(
                name: "ReviewBasicElements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewBasicElements",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ElementDesc = table.Column<string>(maxLength: 200, nullable: true),
                    ElementName = table.Column<string>(maxLength: 100, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    TotalScore = table.Column<int>(nullable: false),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewBasicElements", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReviewLevel2Elements",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BasicElementId = table.Column<Guid>(nullable: false),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ElementName = table.Column<string>(maxLength: 100, nullable: false),
                    ElementStandard = table.Column<string>(maxLength: 500, nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    Order = table.Column<string>(nullable: false),
                    TotalScore = table.Column<int>(nullable: false),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
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
    }
}
