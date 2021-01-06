using Microsoft.EntityFrameworkCore.Migrations;

namespace BarCodeScanner_api.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetupModels_ProductRecords_ProductRecordsId",
                table: "SetupModels");

            migrationBuilder.DropIndex(
                name: "IX_SetupModels_ProductRecordsId",
                table: "SetupModels");

            migrationBuilder.DropColumn(
                name: "ProductRecordsId",
                table: "SetupModels");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRecords_DeviceId",
                table: "ProductRecords",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRecords_SetupModels_DeviceId",
                table: "ProductRecords",
                column: "DeviceId",
                principalTable: "SetupModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRecords_SetupModels_DeviceId",
                table: "ProductRecords");

            migrationBuilder.DropIndex(
                name: "IX_ProductRecords_DeviceId",
                table: "ProductRecords");

            migrationBuilder.AddColumn<int>(
                name: "ProductRecordsId",
                table: "SetupModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SetupModels_ProductRecordsId",
                table: "SetupModels",
                column: "ProductRecordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SetupModels_ProductRecords_ProductRecordsId",
                table: "SetupModels",
                column: "ProductRecordsId",
                principalTable: "ProductRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
