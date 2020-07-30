using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class AdicionandorelacaoMparaMServicoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Itens_ItemId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_ItemId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Servicos");

            migrationBuilder.CreateTable(
                name: "ServicosItens",
                columns: table => new
                {
                    ServicoId = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosItens", x => new { x.ServicoId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ServicosItens_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicosItens_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicosItens_ItemId",
                table: "ServicosItens",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicosItens");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Servicos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_ItemId",
                table: "Servicos",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Itens_ItemId",
                table: "Servicos",
                column: "ItemId",
                principalTable: "Itens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
