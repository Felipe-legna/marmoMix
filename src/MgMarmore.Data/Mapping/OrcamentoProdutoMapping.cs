using MgMarmore.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgMarmore.Data.Mapping
{
    public class OrcamentoProdutoMapping : IEntityTypeConfiguration<OrcamentoProduto>
    {
        public void Configure(EntityTypeBuilder<OrcamentoProduto> builder)
        {
            builder.HasKey(op => new { op.OrcamentoId, op.ProdutoId });

            builder.HasOne(op => op.Orcamento)
                .WithMany(op => op.OrcamentosProdutos)
                .HasForeignKey(op => op.OrcamentoId);

            builder.HasOne(op => op.Produto)
               .WithMany(op => op.OrcamentosProdutos)
               .HasForeignKey(op => op.ProdutoId);

            builder.ToTable("OrcamentosProdutos");
        }
    }
}
