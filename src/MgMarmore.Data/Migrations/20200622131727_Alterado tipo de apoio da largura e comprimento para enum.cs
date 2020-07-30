using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class Alteradotipodeapoiodalarguraecomprimentoparaenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApoioLargura",
                table: "Pecas",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");

            migrationBuilder.AlterColumn<string>(
                name: "ApoioComprimento",
                table: "Pecas",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ApoioLargura",
                table: "Pecas",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ApoioComprimento",
                table: "Pecas",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");
        }
    }
}
