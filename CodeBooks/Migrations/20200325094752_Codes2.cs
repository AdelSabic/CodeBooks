using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeBooks.Migrations
{
    public partial class Codes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false, maxLength: 100),
                    Title = table.Column<string>(nullable: false, maxLength: 200),
                    Company = table.Column<string>(nullable: true),
                    Integer = table.Column<int>(nullable: true),
                    String = table.Column<string>(nullable: true),
                    Decimal = table.Column<decimal>(nullable: true),
                    Ordinal = table.Column<int>(nullable: true),
                    CodeId = table.Column<int>(nullable: true),
                    CodebookId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Codes_Codes_CodeId",
                        column: x => x.CodeId,
                        principalTable: "Codes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Codes_Codebooks_CodebookId",
                        column: x => x.CodebookId,
                        principalTable: "Codebooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Codes_Code",
                table: "Codes",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_CodeId",
                table: "Codes",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Codes_CodebookId",
                table: "Codes",
                column: "CodebookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Codes");
        }
    }
}
