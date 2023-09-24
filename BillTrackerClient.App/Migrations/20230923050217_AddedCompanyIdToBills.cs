using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillTrackerClient.App.Migrations
{
    public partial class AddedCompanyIdToBills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_CompanyId",
                table: "Bills",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Companies_CompanyId",
                table: "Bills",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Companies_CompanyId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_CompanyId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Bills");
        }
    }
}
