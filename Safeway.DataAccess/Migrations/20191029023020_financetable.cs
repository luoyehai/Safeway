using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safeway.DataAccess.Migrations
{
    public partial class financetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnterpriseFinanceInfos",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(maxLength: 50, nullable: true),
                    UnifiedSocialCreditCode = table.Column<string>(maxLength: 50, nullable: true),
                    Company_Address = table.Column<string>(maxLength: 50, nullable: true),
                    Tele_Number = table.Column<string>(maxLength: 50, nullable: true),
                    Bank = table.Column<string>(maxLength: 50, nullable: true),
                    Account = table.Column<string>(maxLength: 50, nullable: true),
                    CustomerReceiptReceiver = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseFinanceInfos", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnterpriseFinanceInfos");
        }
    }
}
