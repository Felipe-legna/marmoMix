using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class ajustadorelacaoclienteendereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.AddColumn<decimal>(
                name: "AlturaDaBase",
                table: "Pecas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Base",
                table: "Pecas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ComprimentoFogaoEmbutido",
                table: "Pecas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalComprimentoPeca",
                table: "Pecas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalLarguraPeca",
                table: "Pecas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "AlturaDaBase",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "Base",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "ComprimentoFogaoEmbutido",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "TotalComprimentoPeca",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "TotalLarguraPeca",
                table: "Pecas");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId");
        }
    }
}
