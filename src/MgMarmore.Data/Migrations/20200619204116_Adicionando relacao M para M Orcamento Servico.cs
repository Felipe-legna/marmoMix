using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class AdicionandorelacaoMparaMOrcamentoServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Orcamentos_OrcamentoId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_OrcamentoId",
                table: "Servicos");

            migrationBuilder.CreateTable(
                name: "OrcamentosServicos",
                columns: table => new
                {
                    OrcamentoId = table.Column<Guid>(nullable: false),
                    ServicoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentosServicos", x => new { x.OrcamentoId, x.ServicoId });
                    table.ForeignKey(
                        name: "FK_OrcamentosServicos_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrcamentosServicos_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentosServicos_ServicoId",
                table: "OrcamentosServicos",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrcamentosServicos");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_OrcamentoId",
                table: "Servicos",
                column: "OrcamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Orcamentos_OrcamentoId",
                table: "Servicos",
                column: "OrcamentoId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
