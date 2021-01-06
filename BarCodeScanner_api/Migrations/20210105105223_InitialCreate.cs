using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarCodeScanner_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInsertDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarCodeData = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetupModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductRecordsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetupModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetupModels_ProductRecords_ProductRecordsId",
                        column: x => x.ProductRecordsId,
                        principalTable: "ProductRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetupModels_ProductRecordsId",
                table: "SetupModels",
                column: "ProductRecordsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetupModels");

            migrationBuilder.DropTable(
                name: "ProductRecords");
        }
    }
}
