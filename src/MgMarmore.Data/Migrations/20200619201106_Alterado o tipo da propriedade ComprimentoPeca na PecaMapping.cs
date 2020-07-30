using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class AlteradootipodapropriedadeComprimentoPecanaPecaMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ComprimentoPeca",
                table: "Pecas",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ComprimentoPeca",
                table: "Pecas",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");
        }
    }
}
