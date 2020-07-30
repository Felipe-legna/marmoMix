using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class Adicionadotipodeitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BancadaId",
                table: "Pecas",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Materiais",
                type: "VARCHAR(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rodape",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemItem",
                table: "Itens",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TipoItemId",
                table: "Itens",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TiposItens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    Imagem = table.Column<string>(type: "VARCHAR(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposItens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bancadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Categoria = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Frontao = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Saia = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Metodo = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Imagem = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    QuantidadePecas = table.Column<int>(type: "INT", nullable: false),
                    MetroQuadrado = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    TipoItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bancadas_TiposItens_TipoItemId",
                        column: x => x.TipoItemId,
                        principalTable: "TiposItens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_BancadaId",
                table: "Pecas",
                column: "BancadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_TipoItemId",
                table: "Itens",
                column: "TipoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Bancadas_TipoItemId",
                table: "Bancadas",
                column: "TipoItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_TiposItens_TipoItemId",
                table: "Itens",
                column: "TipoItemId",
                principalTable: "TiposItens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_Bancadas_BancadaId",
                table: "Pecas",
                column: "BancadaId",
                principalTable: "Bancadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_TiposItens_TipoItemId",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_Bancadas_BancadaId",
                table: "Pecas");

            migrationBuilder.DropTable(
                name: "Bancadas");

            migrationBuilder.DropTable(
                name: "TiposItens");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_BancadaId",
                table: "Pecas");

            migrationBuilder.DropIndex(
                name: "IX_Itens_TipoItemId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "BancadaId",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "ImagemItem",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "TipoItemId",
                table: "Itens");

            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Materiais",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rodape",
                table: "Itens",
                type: "DECIMAL(10,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10,3)");
        }
    }
}
