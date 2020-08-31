using Microsoft.EntityFrameworkCore.Migrations;

namespace Multilingual.MigrationTool.Migrations
{
    public partial class ProductIsAutomatic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAutomatic",
                table: "Translation",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAutomatic",
                table: "Translation");
        }
    }
}
