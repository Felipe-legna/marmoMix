using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class AdicionandorelacaoMparaMOrcamentoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_OrcamentoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "OrcamentoId",
                table: "Produtos");

            migrationBuilder.AddColumn<Guid>(
                name: "OrcamentosId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrcamentosProdutos",
                columns: table => new
                {
                    OrcamentoId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentosProdutos", x => new { x.OrcamentoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_OrcamentosProdutos_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrcamentosProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_OrcamentosId",
                table: "Produtos",
                column: "OrcamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentosProdutos_ProdutoId",
                table: "OrcamentosProdutos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentosId",
                table: "Produtos",
                column: "OrcamentosId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentosId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "OrcamentosProdutos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_OrcamentosId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "OrcamentosId",
                table: "Produtos");

            migrationBuilder.AddColumn<Guid>(
                name: "OrcamentoId",
                table: "Produtos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_OrcamentoId",
                table: "Produtos",
                column: "OrcamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Orcamentos_OrcamentoId",
                table: "Produtos",
                column: "OrcamentoId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
