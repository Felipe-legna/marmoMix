using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class Removidoorcamentodaclasseproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentosId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_OrcamentosId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "OrcamentosId",
                table: "Produtos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrcamentosId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_OrcamentosId",
                table: "Produtos",
                column: "OrcamentosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentosId",
                table: "Produtos",
                column: "OrcamentosId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
