using Microsoft.EntityFrameworkCore.Migrations;

namespace DOANASP.Migrations
{
    public partial class editAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diachi",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diachi",
                table: "Accounts");
        }
    }
}
