using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Multilingual.MigrationTool.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultilingualStrings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultilingualStrings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductNameId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MultilingualStrings_ProductNameId",
                        column: x => x.ProductNameId,
                        principalTable: "MultilingualStrings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    MultilingualStringId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translation_MultilingualStrings_MultilingualStringId",
                        column: x => x.MultilingualStringId,
                        principalTable: "MultilingualStrings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductNameId",
                table: "Products",
                column: "ProductNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_MultilingualStringId",
                table: "Translation",
                column: "MultilingualStringId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "MultilingualStrings");
        }
    }
}
