using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MgMarmore.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(12)", nullable: false),
                    TipoCliente = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoriaId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Custo = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materiais_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    TipoEndereco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),                  
                    Observacoes = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Clientes_ClienteId1",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrcamentoId = table.Column<Guid>(nullable: false),
                    MaterialId = table.Column<Guid>(nullable: false),
                    Saia = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Frontao = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Profundidade = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Borda = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Tampao = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Rodape = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    RodapeComprimento = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    RodapeTotal = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    MetroQuadradoTotal = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    QuantidadeItens = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Materiais_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrcamentoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Custo = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pecas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    LarguraPeca = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    ApoioLargura = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    ComprimentoPeca = table.Column<decimal>(nullable: false),
                    ApoioComprimento = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false),
                    MetroQuadradoPeca = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pecas_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrcamentoId = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicos_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_MaterialId",
                table: "Itens",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_OrcamentoId",
                table: "Itens",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_CategoriaId",
                table: "Materiais",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_ClienteId1",
                table: "Orcamentos",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_ItemId",
                table: "Pecas",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_OrcamentoId",
                table: "Produtos",
                column: "OrcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_ItemId",
                table: "Servicos",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_OrcamentoId",
                table: "Servicos",
                column: "OrcamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Pecas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.DropTable(
                name: "Orcamentos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
