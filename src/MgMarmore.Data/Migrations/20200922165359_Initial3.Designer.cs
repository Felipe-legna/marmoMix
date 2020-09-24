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
    [Migration("20200922165359_Initial3")]
    partial class Initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MgMarmore.Business.Models.CategoriaMaterial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("CategoriasMateriais");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.CategoriaProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("Id");

                    b.ToTable("CategoriasProdutos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.HasKey("Id");

                    b.HasIndex("Telefone");

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

            modelBuilder.Entity("MgMarmore.Business.Models.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoriaMaterialId");

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

                    b.HasIndex("CategoriaMaterialId");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Orcamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(550)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("DECIMAL(10,3)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.OrcamentoProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Desconto");

                    b.Property<Guid>("OrcamentoId");

                    b.Property<Guid>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("OrcamentosProdutos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<Guid>("CategoriaProdutoId");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("TipoProduto")
                        .IsRequired();

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Endereco", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("MgMarmore.Business.Models.Endereco", "ClienteId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Material", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.CategoriaMaterial", "CategoriaMaterial")
                        .WithMany("Materiais")
                        .HasForeignKey("CategoriaMaterialId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Orcamento", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.OrcamentoProduto", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.Orcamento", "Orcamento")
                        .WithMany("Itens")
                        .HasForeignKey("OrcamentoId");

                    b.HasOne("MgMarmore.Business.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("MgMarmore.Business.Models.Produto", b =>
                {
                    b.HasOne("MgMarmore.Business.Models.CategoriaProduto", "CategoriaProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaProdutoId");
                });
#pragma warning restore 612, 618
        }
    }
}