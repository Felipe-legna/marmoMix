﻿// <auto-generated />
using System;
using MgMarmore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MgMarmore.Data.Migrations
{
    [DbContext(typeof(MgContext))]
    [Migration("20200711193150_Adicionado id do tipo de item na bancada")]
    partial class Adicionadoiddotipodeitemnabancada
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MgMarmore.Business.Models.Bancada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Frontao")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<string>("Imagem")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Metodo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("MetroQuadrado")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<int>("QuantidadePecas")
                        .HasColumnType("INT");

                    b.Property<decimal>("Saia")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<Guid>("TipoItemId");

                    b.HasKey("Id");

                    b.HasIndex("TipoItemId");

                    b.ToTable("Bancadas");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(12)");

                    b.Property<string>("TipoCliente")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TipoEndereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Borda")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<decimal?>("Frontao")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<string>("ImagemItem")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("MetroQuadradoTotal")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<Guid>("OrcamentoId");

                    b.Property<decimal?>("Profundidade")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<int>("QuantidadeItens")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Rodape")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<decimal?>("RodapeComprimento")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<decimal?>("RodapeTotal")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<decimal?>("Saia")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<decimal?>("Tampao")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<Guid?>("TipoItemId");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("DECIMAL(10,3)");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.HasIndex("TipoItemId");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoriaId");

                    b.Property<decimal?>("Custo")
                        .IsRequired()
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<string>("Imagem")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(10,3)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Orcamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Observacoes")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("DECIMAL(10,3)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.OrcamentoProduto", b =>
                {
                    b.Property<Guid>("OrcamentoId");

                    b.Property<Guid>("ProdutoId");

                    b.HasKey("OrcamentoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("OrcamentosProdutos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.OrcamentoServico", b =>
                {
                    b.Property<Guid>("OrcamentoId");

                    b.Property<Guid>("ServicoId");

                    b.HasKey("OrcamentoId", "ServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("OrcamentosServicos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Peca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AlturaDaBase");

                    b.Property<string>("ApoioComprimento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("ApoioLargura")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid?>("BancadaId");

                    b.Property<int>("Base");

                    b.Property<decimal>("ComprimentoFogaoEmbutido");

                    b.Property<decimal>("ComprimentoPeca")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<Guid>("ItemId");

                    b.Property<decimal>("LarguraPeca")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<Guid>("MaterialId");

                    b.Property<decimal>("MetroQuadradoPeca")
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<decimal>("TotalComprimentoPeca");

                    b.Property<decimal>("TotalLarguraPeca");

                    b.HasKey("Id");

                    b.HasIndex("BancadaId");

                    b.HasIndex("ItemId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Pecas");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Custo")
                        .IsRequired()
                        .HasColumnType("DECIMAL(10,3)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(10,3)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Servico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(10,3)");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.ServicosItens", b =>
                {
                    b.Property<Guid>("ServicoId");

                    b.Property<Guid>("ItemId");

                    b.HasKey("ServicoId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("ServicosItens");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.TipoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Imagem")
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("TiposItens");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Bancada", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.TipoItem", "TipoItem")
                        .WithMany("Bancadas")
                        .HasForeignKey("TipoItemId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Endereco", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("MgMarmore.Business.Models.Endereco", "ClienteId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Item", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Orcamento", "Orcamento")
                        .WithMany("Itens")
                        .HasForeignKey("OrcamentoId");

                    b.HasOne("MgMarmore.Business.Models.TipoItem", "TipoItem")
                        .WithMany()
                        .HasForeignKey("TipoItemId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Material", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Categoria", "Categoria")
                        .WithMany("Materiais")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Orcamento", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Cliente", "Cliente")
                        .WithMany("Orcamentos")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.OrcamentoProduto", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Orcamento", "Orcamento")
                        .WithMany("OrcamentosProdutos")
                        .HasForeignKey("OrcamentoId");

                    b.HasOne("MgMarmore.Business.Models.Produto", "Produto")
                        .WithMany("OrcamentosProdutos")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.OrcamentoServico", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Orcamento", "Orcamento")
                        .WithMany("OrcamentosServicos")
                        .HasForeignKey("OrcamentoId");

                    b.HasOne("MgMarmore.Business.Models.Servico", "Servico")
                        .WithMany("OrcamentosServicos")
                        .HasForeignKey("ServicoId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Peca", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Bancada")
                        .WithMany("PecasBancada")
                        .HasForeignKey("BancadaId");

                    b.HasOne("MgMarmore.Business.Models.Item", "Item")
                        .WithMany("Pecas")
                        .HasForeignKey("ItemId");

                    b.HasOne("MgMarmore.Business.Models.Material", "Material")
                        .WithMany("Pecas")
                        .HasForeignKey("MaterialId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.ServicosItens", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Item", "Item")
                        .WithMany("ServicosItens")
                        .HasForeignKey("ItemId");

                    b.HasOne("MgMarmore.Business.Models.Servico", "Servico")
                        .WithMany("ServicosItens")
                        .HasForeignKey("ServicoId");
                });
#pragma warning restore 612, 618
        }
    }
}
