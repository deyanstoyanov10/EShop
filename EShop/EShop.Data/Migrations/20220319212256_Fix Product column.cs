using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShop.Data.Migrations
{
    public partial class FixProductcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Products",
                newName: "Active");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Products",
                newName: "Status");
        }
    }
}
